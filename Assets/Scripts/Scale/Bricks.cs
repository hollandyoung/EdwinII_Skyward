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
        BrickCounter.text = ("You Have: " + BrickCount + " Bricks");
    }
    public void SetBrickCount(float BrickSet)
    {
        BrickCount = BrickSet;
        BrickCounter.text = ("You Have: " + BrickCount + " Bricks");
        if (BrickCount == 0) {
            BrickCounter.text = ("You are broke");
        }
    }
}
