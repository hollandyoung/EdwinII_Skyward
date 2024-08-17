using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject BuildButton;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveStartButton(true);
        SetActiveRestartButton(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveStartButton(bool active)
    {
        startButton.SetActive(active);
    }
    public void SetActiveRestartButton(bool active)
    {
        restartButton.SetActive(active);
    }
}
