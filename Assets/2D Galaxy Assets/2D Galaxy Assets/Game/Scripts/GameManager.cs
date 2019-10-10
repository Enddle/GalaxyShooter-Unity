using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject Player = null;
    public bool gameOver = true;
    private UIManager UI = null;

    // Start is called before the first frame update
    void Start() {
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update() {
        
        if (gameOver) {

            if (Input.GetKeyDown(KeyCode.Space)) {

                Instantiate(Player, new Vector3(0,0,0), Quaternion.identity);
                gameOver = false;
                Debug.Log("Game Start");
                UI.HideTitleScreen();
            }
        }
    }
}
