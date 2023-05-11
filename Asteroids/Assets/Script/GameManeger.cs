using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        textScore.text = score.ToString();
        finalScore.text = score.ToString();
    }

    
    public void IncreaseScore()
    {
        score += 10;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
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