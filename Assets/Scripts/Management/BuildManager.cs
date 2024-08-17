using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public string currType;

    private float weightL;
    private float weightR;

    // Start is called before the first frame update
    void Start()
    {
        currType = "house";
        weightL = 0f;
        weightR = 0f;
    }

    public void SetType(string type)
    {
        currType = type;
    }

    public void SetHouse()
    {
        currType = "house";
    }

    public void SetPlatform()
    {
        currType = "platform";
    }

    public void SetColumn()
    {
        currType = "column";
    }

    public string GetBuildType()
    {
        return currType;
    }

    public void UpdateWeight(string type, bool side)
    {
        
    }
}
