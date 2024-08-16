using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject Bricker;
    private Bricks Brick;


    // Variables
    private string houseType;

    public string GetHouseType()
    {
        return houseType;
    }
    void Start()
    {
        Brick = Bricker.GetComponent<Bricks>();
        StartCoroutine(ProduceBricks());
    }

    IEnumerator ProduceBricks()
    {
       //Wait for 4 seconds
        yield return new WaitForSeconds(4);
        Brick.AddBrickCount();
    }
}
