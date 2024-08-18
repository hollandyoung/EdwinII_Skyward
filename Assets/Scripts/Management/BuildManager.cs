using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildManager : MonoBehaviour
{
    [SerializeField] BeamTilt beamTilt;
    [SerializeField] GameObject slotPrefab;
    public string currType;
    [SerializeField] Transform pan1;
    [SerializeField] Transform pan2;

    private int weightL;
    private int weightR;

    private int countL;
    private int countR;

    public GameObject[,] leftSide = new GameObject[8, 5];
    public GameObject[,] rightSide = new GameObject[8, 5];
    public bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        currType = "house";
        weightL = 0;
        weightR = 0;
        initialized = false;
        
        GenerateSlots();
        initialized = true;
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
    public void SetApartment()
    {
        currType = "apartment";
    }

    public void SetDestroy()
    {
        currType = "destroy";
    }

    public string GetBuildType()
    {
        return currType;
    }

    public void UpdateWeight(string type, bool rightSide)
    {
        int weightMod = 1;
        int dir;

        switch (type)
        {
            case "column":
                weightMod = 1;
                break;
            case "platform":
                weightMod = 1;
                break;
            case "house":
                weightMod = 1;
                break;
            default:
                weightMod = 1;
                break;
        }

        if (rightSide)
        {
            weightR += weightMod;
            dir = -1;
            countR++;
        }
        else
        {
            weightL += weightMod;
            dir = 1;
            countL++;
        }

        beamTilt.WeightAdded(weightMod, dir);
    }

    public int GetWeightLeft()
    {
        return weightL;
    }

    public int GetWeightRight()
    {
        return weightR;
    }

    // Generated from the bottom left to the top right
    private void GenerateSlots()
    {
        for (int row = 0; row < leftSide.GetLength(0); row++)
        {
            for (int col = 0; col < leftSide.GetLength(1); col++)
            {
                leftSide[row, col] = Instantiate(slotPrefab, pan1);
                leftSide[row, col].GetComponent<AnnoyingSlot>().SetCoords(row, col);
                leftSide[row, col].GetComponent<AnnoyingSlot>().SetSide(false);

                rightSide[row, col] = Instantiate(slotPrefab, pan2);
                rightSide[row, col].GetComponent<AnnoyingSlot>().SetCoords(row, col);
                rightSide[row, col].GetComponent<AnnoyingSlot>().SetSide(true);
            }
        }
    }
}
