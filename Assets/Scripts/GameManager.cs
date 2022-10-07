using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool isGameStarted = false;
    public GameObject platformSpawner;
    public GameObject gameplayUI;
    public GameObject menuUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        } 
    }
    // Start is called before the first frame update
    void Start() {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Mejor puntuacion: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted) {
            if(Input.GetMouseButtonDown(0)) {
                GameStart();
            }
        }
    }

    public void GameStart() {
        isGameStarted = true;
        platformSpawner.SetActive(true);
        gameplayUI.SetActive(true);
        menuUI.SetActive(false);
        StartCoroutine(UpdateScore());
    }

    public void GameOver() {
        isGameStarted = false;
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        gameplayUI.SetActive(false);
        menuUI.SetActive(true);
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel() {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore() {
        while (isGameStarted) {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
    }

    void SaveHighScore() {
        if (PlayerPrefs.HasKey("HighScore")) {
            if (score > PlayerPrefs.GetInt("HighScore")) {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
