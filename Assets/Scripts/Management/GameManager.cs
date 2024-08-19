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
    [SerializeField] GameObject createTowerObject;
    [SerializeField] GameObject cameraObject;
    [SerializeField] GameObject towerObject;
    [SerializeField] GameObject beamObject;
    private BeamTilt beamTilter;
    private UIManager uIManagerScript;
    private CreateTower edwinManager;

    // Start is called before the first frame update
    void Start()
    {
        uIManagerScript = uIManagerObject.GetComponent<UIManager>();
        edwinManager = createTowerObject.GetComponent<CreateTower>();
        beamTilter = beamObject.GetComponent<BeamTilt>();
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
        timerRunning = false;
        endScore = (int) timeAlive;
        if (endScore > highScore)
        {
            highScore = endScore;
            uIManagerScript.newHighScore = true;
        }
        uIManagerScript.UpdateScores();
        edwinManager.TowerBackDown();
        beamTilter.SetBeamTiltVelocity(0);
        beamTilter.SetBeamTiltAcceleration(0);
    }

    public int GetEndScore()
    {
        return endScore;
    }
    public string GetEndScoreDisplayValue()
    {
        return string.Format("{0:0}:{1:00}", Mathf.FloorToInt(endScore / 60), (Mathf.FloorToInt(endScore % 60)));
    }
    public string GetTimeAliveDisplayValue()
    {
        return string.Format("{0:0}:{1:00}", Mathf.FloorToInt((float)timeAlive / 60), (Mathf.FloorToInt((float)timeAlive % 60)));
    }
    public string GetHighScoreDisplayValue()
    {
        return string.Format("{0:0}:{1:00}", Mathf.FloorToInt(highScore / 60), (Mathf.FloorToInt(endScore % 60)));
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
