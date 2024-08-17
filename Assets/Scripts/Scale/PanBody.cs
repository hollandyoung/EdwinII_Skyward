using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBody : MonoBehaviour
{
    // Objects
    [SerializeField] GameObject gM; // Game manager

    // Scripts
    GameManager gMScript;

    void Start()
    {
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
    #endregion
}
