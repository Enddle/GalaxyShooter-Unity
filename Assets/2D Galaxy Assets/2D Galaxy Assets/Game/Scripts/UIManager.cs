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
    private int highScore = 0;

    // Start is called before the first frame update
    void Start() {

        GetHighScore();
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

        CheckHighScore();
        ScoreText.text = "Score: " + score + "\nHigh: " + highScore;
    }

    public void HideTitleScreen() {

        TitleScreen.SetActive(false);
        score = 0;

        CheckHighScore();
        ScoreText.text = "Score: " + score + "\nHigh: " + highScore;
    }

    public void ShowTitleScreen() {
        
        TitleScreen.SetActive(true);
    }

    private void CheckHighScore() {

        if (score > highScore) {

            highScore = score;
            UpdateHighScore();
        }
    }

    private void GetHighScore() {

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        ScoreText.text = "Score: " + score + "\nHigh: " + highScore;
    }

    private void UpdateHighScore() {

        Debug.Log("Updated " + highScore);

        PlayerPrefs.SetInt("HighScore", highScore);
    }
}
