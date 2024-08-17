using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public string currType;

    // Start is called before the first frame update
    void Start()
    {
        currType = "house";
    }

    public void SetType(string type)
    {
        currType = type;
    }

    public string GetBuildType()
    {
        return currType;
    }
}
