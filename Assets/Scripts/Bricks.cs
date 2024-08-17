using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public float BrickCount = 70.0f;
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
    public void AddBrickCount()
    {
        BrickCount += 1;
    }
    public void SetBrickCount(float BrickSet)
    {
        BrickCount = BrickSet;
    }
}
