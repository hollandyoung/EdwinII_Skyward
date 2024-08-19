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

    // Vars for image
    [SerializeField] Image instructionsPic;

    [SerializeField] Sprite[] images;
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

        if (images[page] == null)
        {
            instructionsPic.enabled = false;
        }
        else
        {
            instructionsPic.enabled = true;
            instructionsPic.sprite = images[page];
        }

        if (page < instructions.Length - 1)
        {
            page++;
        } else
        {
            page = 0;
        }
    }
}
