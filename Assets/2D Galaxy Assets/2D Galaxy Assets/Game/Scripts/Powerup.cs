using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    private float speed = 3f;

    [SerializeField] private Type type = 0;
    [SerializeField] private AudioClip powerupClip = null;

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
            
                p.PowerUp(type);

                if (powerupClip == null) Debug.Log("no powerup clip.");
                AudioSource.PlayClipAtPoint(powerupClip, Camera.main.transform.position);

                Destroy(this.gameObject);
            }
        }
    }

    public enum Type {
        None,
        TripleShot,
        MaxShot,
        SpeedBoost,
        Shield
    }
}
