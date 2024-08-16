using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.SetActive(true);
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
