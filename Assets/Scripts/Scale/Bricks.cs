using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bricks : MonoBehaviour
{

    public TextMeshProUGUI BrickCounter;
    
    
    public float BrickCount = 70.0f;
    // Start is called before the first frame update
    void Start()
    {
        //BrickCounter = Text.Find("Brick Counter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetBrickCount()
    {
        return BrickCount;
    }
    public void AddBrickCount()
    {
        BrickCount += 1;
        UpdateCount();
    }
    public void SetBrickCount(float BrickSet)
    {
        BrickCount = BrickSet;
        UpdateCount();
    }
    public void UpdateCount()
    {
        if (BrickCount >= 1000)
        {
            // Truncates Brick Count text if over 1000 (e.g. 1234 -> 1.2K)
            BrickCounter.text = (Mathf.Floor(BrickCount / 100) / 10 + "K");
        } else
        {
            BrickCounter.text = (BrickCount + "");
        }
    }
}
