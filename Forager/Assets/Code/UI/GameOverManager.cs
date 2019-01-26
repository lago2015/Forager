using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour {

    
    private int highScoreInt;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverWindow;


    private void Awake()
    {
        gameOverWindow.SetActive(false);
    }

    public void StartCountdownToGameOver(int currentScore)
    {
        scoreText.text = "Score: " + currentScore;
        highScoreInt = PlayerPrefs.GetInt("highScore");
        if(currentScore>highScoreInt)
        {
            highScoreInt = currentScore;
            PlayerPrefs.SetInt("highScore", highScoreInt);
        }
        highScoreText.text = "High Score: " + highScoreInt;
        StartCoroutine(WaitToDisplayGameOver());
    }

    IEnumerator WaitToDisplayGameOver()
    {
        yield return new WaitForSeconds(1f);

        gameOverWindow.SetActive(true);
    }

}
