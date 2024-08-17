using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBody : MonoBehaviour
{
    // Instance Variables
    private int houseCount;

    // Objects
    [SerializeField] GameObject gM; // Game manager

    // Scripts
    GameManager gMScript;

    void Start()
    {
        houseCount = 0;

        gMScript = gM.GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            gMScript.EndGame();
        }
        Debug.Log(collision.gameObject.layer);
    }

    // NEED TO FIX PLEASE
    #region
    public float GetWeight()
    {
        float weight = 0f;
        /*for (int i = 0; i < positions.Length; i++)
        {
            weight += positions[i].GetComponentInChildren<HouseStack>().GetWeight();
        }*/
        return weight;
    }

    public int GetCount()
    {
        return houseCount;
    }

    public void AddCount()
    {
        houseCount++;
    }
    #endregion
}
