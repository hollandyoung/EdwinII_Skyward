using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject Bricker;
    private Bricks Brick;
    public float WaitTime = 4.0f;
    public bool MakeBricks = true;

    // Variables
    private string houseType;

    public string GetHouseType()
    {
        return houseType;
    }

    public void SetHouseType(string type)
    {
        houseType = type;
    }

    void Start()
    {
        Bricker = GameObject.Find("Brick Manager");
        Brick = Bricker.GetComponent<Bricks>();
        StartCoroutine(ProduceBricks());
    }

    IEnumerator ProduceBricks()
    {
        while (MakeBricks) {
       //Wait for 4 seconds
        yield return new WaitForSeconds(WaitTime);
        Brick.AddBrickCount();
        }
    }

    public int GetWeight()
    {
        switch (this.houseType)
        {
            case "color":
                return 1;
            case "heavy":
                return 3;
            case "float":
                return 1;
            case "grow":
                return 10;
            default:
                return 1;
        }
    }
}
