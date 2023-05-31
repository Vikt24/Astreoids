using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public static GameManeger instance;
    public TMP_Text textScore, finalScore;
    private int score;
    

    private void Awake()
    { 
        instance = this;
    }

    private void Update()
    {
        //changes score texts
        try
        {
            textScore.text = score.ToString();
            finalScore.text = score.ToString();
        }
        catch
        {

        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PreaviusScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void IncreaseScore()
    {
        score += 10;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        Time.timeScale = 0;        
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}