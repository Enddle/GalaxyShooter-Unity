using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Sprite[] LiveImages = null;
    [SerializeField] private Image LiveImageDisplay = null;
    [SerializeField] private Text ScoreText = null;
    [SerializeField] private GameObject TitleScreen = null;

    private int score = 0;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void UpdateLives(int currentLives) {

        if (currentLives < 0 || currentLives > 3) {
            return;
        }

        LiveImageDisplay.sprite = LiveImages[currentLives];
    }

    public void UpdateScores() {

        score += 10;

        ScoreText.text = "Score: " + score;
    }

    public void HideTitleScreen() {

        TitleScreen.SetActive(false);
        score = 0;
        ScoreText.text = "Score: " + score;
    }

    public void ShowTitleScreen() {
        
        TitleScreen.SetActive(true);
    }
}
