using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayerR : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start() {

        transform.position = new Vector3(16, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        
        Movement();
    }

    private void Movement() {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        //bounds
        if (transform.position.y > 0) {
            
            transform.position = new Vector3(transform.position.x, 0, 0);

        } else if (transform.position.y < -3.6) {
            
            transform.position = new Vector3(transform.position.x, -3.6f, 0);
        }

        if (transform.position.x > 24) {
            
            transform.position = new Vector3(8f, transform.position.y, 0);

        } else if (transform.position.x < 8) {
            
            transform.position = new Vector3(24f, transform.position.y, 0);
        }
    }
}
