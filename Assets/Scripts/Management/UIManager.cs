using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject BuildButton;
    [SerializeField] GameObject HouseButton;
    [SerializeField] GameObject ColumnButton;
    [SerializeField] GameObject PlatformButton;
    [SerializeField] GameObject KilnButton;
    [SerializeField] GameObject AgoraButton;
    [SerializeField] GameObject ApartmentButton;
    [SerializeField] TextMeshProUGUI currentTimer;
    [SerializeField] TextMeshProUGUI endTimer;
    [SerializeField] TextMeshProUGUI highScoreObject;
    public bool newHighScore;
    [SerializeField] GameObject gM;
    private GameManager gMScript;

    // Start is called before the first frame update
    void Start()
    {
        gMScript = gM.GetComponent<GameManager>();
        SetActiveRestartButton(false);
        SetActiveEndTimer(false);
        SetActiveHighScore(false);
        newHighScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer.text = gMScript.GetTimeAliveDisplayValue();
    }

    public void UpdateScores()
    {
        SetActiveRestartButton(true);
        SetActiveEndTimer(true);
        SetActiveHighScore(true);
        if(newHighScore == true)
        {
            highScoreObject.text = "NEW HIGH SCORE";
        }
        else
        {
            highScoreObject.text = ("BEST: " + gMScript.GetHighScoreDisplayValue());
        }
        endTimer.text = gMScript.GetEndScoreDisplayValue();
    }

    public void SetActiveRestartButton(bool active)
    {
        restartButton.SetActive(active);
    }
    public void SetActiveEndTimer(bool active)
    {
        endTimer.enabled = active;
    }
    public void SetActiveHighScore(bool active)
    {
        highScoreObject.enabled = active;
    }
}
