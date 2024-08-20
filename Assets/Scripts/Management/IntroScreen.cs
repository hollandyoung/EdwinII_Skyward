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
    private RectTransform instructionsRect;

    [SerializeField] Sprite[] images;
    int page = 0;

    private void Start()
    {
        instructionsRect = instructionsPic.gameObject.GetComponent<RectTransform>();
    }

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

        if (page == 11)
        {
            instructionsRect.localScale = new Vector3(2f, 1f, 1f);
            instructionsRect.localPosition = new Vector3(0, 220, 0);
        }
        else if (page == 12)
        {
            instructionsRect.localScale = new Vector3(1.5f, 1f, 1f);
            instructionsRect.localPosition = new Vector3(0, 190, 0);
        }
        else
        {
            instructionsRect.localScale = new Vector3(1f, 1f, 1f);
        }

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
