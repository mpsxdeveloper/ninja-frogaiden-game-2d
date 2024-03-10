using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public Text scoreText;
    public Text livesText;
    public GameObject gameOver;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {      
        if(PlayerPrefs.HasKey("TOTAL_SCORE")) {
            Global.totalScore = PlayerPrefs.GetInt("TOTAL_SCORE");
        }
        else {
            PlayerPrefs.SetInt("TOTAL_SCORE", Global.totalScore);
            PlayerPrefs.Save();
        }
        if(PlayerPrefs.HasKey("TOTAL_LIVES")) {
            Global.totalLives = PlayerPrefs.GetInt("TOTAL_LIVES");
        }
        else {
            PlayerPrefs.SetInt("TOTAL_LIVES", Global.totalLives);
            PlayerPrefs.Save();
        }
        instance = this;
        UpdateLivesText();
        UpdateScoreText();
    }

    public void UpdateScoreText() {
        scoreText.text = Global.totalScore.ToString();
    }

    public void UpdateLivesText() {
        livesText.text = Global.totalLives.ToString();
    }

    public void UpdateScore(int value) {        
        PlayerPrefs.SetInt("TOTAL_SCORE", Global.totalScore+=value);
        PlayerPrefs.Save();
        UpdateScoreText();    
    }

    public void UpdateLives() {
        Global.totalLives--; 
        PlayerPrefs.SetInt("TOTAL_LIVES", Global.totalLives);
        PlayerPrefs.Save();
        UpdateLivesText();
        if(Global.totalLives == 0) {
            ShowGameOver();
        }
        else {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void ShowGameOver() {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName) {
        lvlName = "Level_1";
        Global.totalLives = 3;
        Global.totalScore = 0;
        SceneManager.LoadScene(lvlName);
    }

    public void PlayItemSound() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

}