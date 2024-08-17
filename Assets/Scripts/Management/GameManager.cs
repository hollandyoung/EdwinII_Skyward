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
    private bool gameActive;
    [SerializeField] GameObject uIManagerObject;
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
        if (gameActive == true)
        {
            timeAlive += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        // Starts the game and resets values for scores
        gameActive = true;
        timeAlive = 0;
        endScore = 0;
    }

    public void RestartGame()
    {
        // Reloads the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        // Stops the game and saves the end score and updates the high score if needed
        //Debug.Log("THE GAME IS OVER!!!!!!!!!!!!!!!!!");
        gameActive = false;
        uIManagerScript.SetActiveRestartButton(true);
        endScore = (int) timeAlive;
        if (endScore > highScore)
        {
            highScore = endScore;
        }
        SceneManager.LoadScene (sceneName:"Game Over");
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
