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

    [SerializeField] private GameObject LaserPrefab = null;
        // SerializeField - shows in Unity

    [SerializeField] private GameObject PlayerExplosion = null;

    private float fireRate = 0.25f;
    private float canFire = 0.05f;

    private bool canTripleShot = false;

    [SerializeField] private GameObject TripleShotPrefab;

    private bool canMaxShot = false;

    [SerializeField] private GameObject MaxShotPrefab;

    [SerializeField] private int lives = 3;

    private bool canShield = false;

    private UIManager UI = null;

    private GameManager gameManager = null;
    private SpawnManager spawnManager = null;
    private AudioSource laserSound = null;

    // methods/functions - blocks of code

    // Start is called before the first frame update
    void Start() {

        UI = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (UI != null) {
            
            UI.UpdateLives(lives);
        }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (spawnManager != null) {

            spawnManager.StartSpawnRoutines();
        }

        laserSound = GetComponent<AudioSource>();
            // dont need Find() or Other
            // is a component of player
        
        // Debug.Log("Hello World");
        // Debug.Log("Name: " + transform.name);
        // Debug.Log("Position: " + transform.position);
        // Debug.Log("X: " + transform.position.x);

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

        if (transform.position.x > 9) {
            
            transform.position = new Vector3(-9f, transform.position.y, 0);

        } else if (transform.position.x < -9) {
            
            transform.position = new Vector3(9f, transform.position.y, 0);
        }
    }

    private void Shoot() {

        // compound boolean test
        // and &&
        // or ||

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {

            if (Time.time > canFire) {
                // Time.time: the time playing the game

                laserSound.Play();
                
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

    public IEnumerator PowerDown(Powerup.Type type) {

        yield return new WaitForSeconds(5f);

        switch (type) {
            
            case Powerup.Type.TripleShot:
                canTripleShot = false;
                break;

            case Powerup.Type.MaxShot:
                canMaxShot = false;
                break;

            case Powerup.Type.SpeedBoost:
                speed = 5f;
                break;
        }
    }

    public void PowerUp(Powerup.Type type) {

        switch (type) {

            case Powerup.Type.TripleShot:
                canTripleShot = true;
                break;

            case Powerup.Type.MaxShot:
                canMaxShot = true;
                break;

            case Powerup.Type.SpeedBoost:
                speed = 7.5f;
                break;
            
            case Powerup.Type.Shield:
                canShield = true;
                this.gameObject.transform.GetChild(0).gameObject.SetActive(canShield);
                break;
        }
        StartCoroutine(PowerDown(type));
    }

    public void Damage() {

        if (canShield) {
            
            canShield = false;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(canShield);

        } else {

            lives--;

            UI.UpdateLives(lives);

            if (lives < 0) {

                Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
                UI.ShowTitleScreen();
                gameManager.gameOver = true;
                Debug.Log("Game Over");
                Destroy(this.gameObject);
            }
        }
    }

}  // end Player
