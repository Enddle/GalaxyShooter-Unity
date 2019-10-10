using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float speed = 3f;

    [SerializeField] private GameObject EnemyExplosion = null;
    private UIManager UI = null;
    private GameManager gameManager = null;

    // Start is called before the first frame update
    void Start() {

        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {

        if (gameManager.gameOver) {

            Destroy(this.gameObject);
        }
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6.5f) {

            float xPos = Random.Range(-7.5f, 7.5f);
            transform.position = new Vector3(xPos, 6.5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        switch (other.tag) {
            case "Laser":
            
                if (other.transform.parent != null) {

                    Instantiate(EnemyExplosion, transform.position, Quaternion.identity);

                    Destroy(other.transform.parent.gameObject);
                
                } else {

                    Instantiate(EnemyExplosion, transform.position, Quaternion.identity);

                    Destroy(other.gameObject);
                        // erase the pic and all that goes with it
                }
                
                if (UI != null) {

                    UI.UpdateScores();
                }

                Destroy(this.gameObject);
                    
                break;

            case "Player":
                
                Player p = other.GetComponent<Player>();

                if (p != null) {

                    p.Damage();

                    Instantiate(EnemyExplosion, transform.position, Quaternion.identity);

                    if (UI != null) {

                        UI.UpdateScores();
                    }

                    Destroy(this.gameObject);
                }
                break;

            default:
                break;
        }
    }
}
