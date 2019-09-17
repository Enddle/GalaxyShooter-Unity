// single line comment

/*
    multi
    line
    comment
 */

// namespaces, import external code
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public/private - accessibility from outside file
// class - building block of the program
// class name - MUST MATCH FILE NAME AND OBJECT NAME EXACTLY
// : - inherits from
// parent(base) class

public class Player : MonoBehaviour {

    // instance fields - var with info
    public float speed = 5.0f;

    [SerializeField] private GameObject LaserPrefab;
        // SerializeField - shows in Unity

    private float fireRate = 0.25f;
    private float canFire = 0.05f;

    private bool canTripleShot = false;

    [SerializeField] private GameObject TripleShotPrefab;

    private bool canMaxShot = false;

    [SerializeField] private GameObject MaxShotPrefab;

    // methods/functions - blocks of code

    // Start is called before the first frame update
    void Start() {
        
        Debug.Log("Hello World");
        Debug.Log("Name: " + transform.name);
        Debug.Log("Position: " + transform.position);
        Debug.Log("X: " + transform.position.x);

        transform.position = new Vector3(0, 0, 0);
    }  // end Start

    // Update is called once per frame
    void Update() {

        Movement();

        Shoot();
    }  // end Update

    private void Movement() {

        // transform.Translate(Vector3.right);
            // (1, 0, 0)
            // too fast

        // transform.Translate(Vector3.right * Time.deltaTime);
            // too slow

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

        if (transform.position.x > 8) {
            
            transform.position = new Vector3(-8f, transform.position.y, 0);

        } else if (transform.position.x < -8) {
            
            transform.position = new Vector3(8f, transform.position.y, 0);
        }
    }

    private void Shoot() {

        // compound boolean test
        // and &&
        // or ||

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {

            if (Time.time > canFire) {
                // Time.time: the time playing the game
                
                if (canMaxShot) {

                    Instantiate(MaxShotPrefab, transform.position + new Vector3(0f, 0.6f, 0f), Quaternion.identity);

                } else if (canTripleShot) {
                    
                    Instantiate(TripleShotPrefab, transform.position + new Vector3(0f, 0.6f, 0f), Quaternion.identity);

                } else {
                    
                    Instantiate(LaserPrefab, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                        // clone (make a laser)
                        // transform.position: at ship's position
                        // Quaternion.identity: rotated as original
                }

                canFire = Time.time + fireRate;
            }
        }
    }

    public IEnumerator ShotPowerdown(bool isMax) {

        yield return new WaitForSeconds(5f);

        if (isMax) {
            canMaxShot = false;
        } else {
            canTripleShot = false;
        }
    }

    public void ShotPowerup(bool isMax) {

        if (isMax) {
            canMaxShot = true;
        } else {
            canTripleShot = true;
        }

        StartCoroutine(ShotPowerdown(isMax));
    }

}  // end Player
