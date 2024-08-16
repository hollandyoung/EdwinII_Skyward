using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public float BrickCount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetBrickCount()
    {
        return BrickCount;
    }
    void AddBrickCount()
    {
        BrickCount += 1;
    }
    void SetBrickCount(float BrickSet)
    {
        BrickCount = BrickSet;
    }
}
