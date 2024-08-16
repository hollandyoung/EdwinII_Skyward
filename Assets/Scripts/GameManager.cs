using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private double timeAlive;
    private int endScore;
    private int highScore;
    private bool gameActive;

    // Start is called before the first frame update
    void Start()
    {
        gameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Counts up the score if the game is running
        if (gameActive == true)
        {
            timeAlive += Time.deltaTime;
        }
    }

    void StartGame()
    {
        // Starts the game and resets values for scores
        gameActive = true;
        timeAlive = 0;
        endScore = 0;
    }

    void EndGame()
    {
        // Stops the game and saves the end score and updates the high score if needed
        gameActive = false;
        endScore = (int) timeAlive;
        if (endScore > highScore)
        {
            highScore = endScore;
        }
    }

    int GetEndScore()
    {
        return endScore;
    }
    int GetHighScore()
    {
        return highScore;
    }
}
