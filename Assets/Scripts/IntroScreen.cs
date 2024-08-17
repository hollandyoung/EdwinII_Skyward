using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class IntroScreen : MonoBehaviour
{
    [SerializeField] string[] instructions;
    [SerializeField] GameObject instructionsScreen;
    [SerializeField] GameObject titleScreen;
    [SerializeField] TextMeshProUGUI instructionsText;
    int page = 0;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Instructions()
    {
        instructionsScreen.SetActive(true);
        titleScreen.SetActive(false);
        NextInstruction();
    }

    public void Title()
    {
        titleScreen.SetActive(true);
        instructionsScreen.SetActive(false);
    }

    public void NextInstruction()
    {
        instructionsText.text = instructions[page];
        if (page < instructions.Length - 1)
        {
            page++;
        } else
        {
            page = 0;
        }
    }
}
