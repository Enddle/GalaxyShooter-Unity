using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    private float speed = 3f;

    [SerializeField] private int powerupId = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6f) {
            
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {  // parameter/argument, link to what we ran into
        
        if (other.tag == "Player") {

            // script communication
            Player p = other.GetComponent<Player>();
                // reach out to find the player object
            
            if (p != null) {

                switch (this.powerupId) {
                    
                    case 1:  // Triple Shot

                        p.Powerup(Player.PowerupType.TripleShot);
                        break;

                    case 2:  // Max Shot

                        p.Powerup(Player.PowerupType.MaxShot);
                        break;

                    case 3:  // Speed Boost

                        p.Powerup(Player.PowerupType.SpeedBoost);
                        break;

                    default:
                        Debug.Log("Powerup Type Error.");
                        break;
                }

                Destroy(this.gameObject);
            }
        }
    }
}
