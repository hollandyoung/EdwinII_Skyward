using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject bricker;
    private Bricks brick;
    public float waitTime = 4.0f;
    public bool makeBricks = true;

    // Variables
    private string houseType;
    private bool rightSide;
    private int col = -1;
    private int row = -1;
    private int[] coords = new int[2];
    public bool initialized = false;
    private int initHelp = 0; // Two when finished

    void Start()
    {
        bricker = GameObject.Find("Brick Manager");
        brick = bricker.GetComponent<Bricks>();
        StartCoroutine(ProduceBricks());
    }

    IEnumerator ProduceBricks()
    {
        // Wait for 4 seconds
        while (makeBricks)
        {
            yield return new WaitForSeconds(waitTime);
            brick.AddBrickCount();
        }
    }

    private void Update()
    {
        if (!initialized && initHelp > 1)
        {
            initialized = true;
        }
    }

    public void SetSide(bool side)
    {
        rightSide = side;
        initHelp++;
    }

    public bool GetSide()
    {
        return rightSide;
    }

    public int GetCol()
    {
        return col;
    }

    public void SetCol(int col)
    {
        this.col = col;
        initHelp++;
    }

    public void SetCoords(int row, int col)
    {
        coords[0] = row;
        coords[1] = col;

        float targX;
        float targY;

        targY = 0.16f + 0.16f * row;
        targX = -0.32f + 0.16f * col;

        transform.localPosition = new Vector3(targX, targY, 0f);
    }
}
