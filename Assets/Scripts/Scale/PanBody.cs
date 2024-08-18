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

    /*void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            gMScript.EndGame();
        }
        Debug.Log(collision.gameObject.layer);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Got here at least");
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("Game Over");
            gMScript.EndGame();
        }
    }
}
