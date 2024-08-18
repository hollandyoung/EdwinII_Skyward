using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private double timeAlive;
    private int endScore;
    private int highScore;
    private bool timerRunning;
    [SerializeField] GameObject uIManagerObject;
    [SerializeField] GameObject cameraObject;
    [SerializeField] GameObject towerObject;
    private UIManager uIManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        uIManagerScript = uIManagerObject.GetComponent<UIManager>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Counts up the score if the game is running
        if (timerRunning == true)
        {
            timeAlive += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        // Starts the game and resets values for scores
        timerRunning = true;
        timeAlive = 0;
        endScore = 0;
    }

    public void RestartGame()
    {
        // Reloads the scene
        SceneManager.LoadScene("IntroScreen");
    }

    public void EndGame()
    {
        // Stops the game and saves the end score and updates the high score if needed
        //Debug.Log("THE GAME IS OVER!!!!!!!!!!!!!!!!!");
        Debug.Log("Fury");
        timerRunning = false;
        uIManagerScript.SetActiveRestartButton(true);
        endScore = (int) timeAlive;
        if (endScore > highScore)
        {
            highScore = endScore;
        }
    }

    public int GetEndScore()
    {
        return endScore;
    }
    public int GetHighScore()
    {
        return highScore;
    }
    public bool GetTimerRunning()
    {
        return timerRunning;
    }
}
