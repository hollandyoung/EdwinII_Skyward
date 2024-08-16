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
}
