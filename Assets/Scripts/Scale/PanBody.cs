using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBody : MonoBehaviour
{
    // Objects
    [SerializeField] GameObject gM; // Game manager

    // Scripts
    GameManager gMScript;
    private SFXManager sFXManager;

    // Instance Variables
    bool prox = false;
    void Start()
    {
        gMScript = gM.GetComponent<GameManager>();
        sFXManager = GameObject.Find("GameManager").GetComponent<SFXManager>();
    }

    private void Update()
    {
        int mask = LayerMask.GetMask("Tower");
        int tideMask = LayerMask.GetMask("Tide");

        float halfLength = gameObject.GetComponent<BoxCollider2D>().bounds.size.x / 2;
        float halfHeight = gameObject.GetComponent<BoxCollider2D>().bounds.size.y / 2;

        RaycastHit2D hitL = Physics2D.Raycast(transform.position + Vector3.left * halfLength, Vector2.left, 0.1f, mask);
        if (hitL.collider != null)
        {
            gMScript.EndGame();
            sFXManager.PlayClip("hit wall");
        }

        RaycastHit2D hitR = Physics2D.Raycast(transform.position + Vector3.right * halfLength, Vector2.right, 0.1f, mask);
        if (hitR.collider != null)
        {
            gMScript.EndGame();
            sFXManager.PlayClip("hit wall");
        }

        RaycastHit2D hitB = Physics2D.Raycast(transform.position + Vector3.down * halfHeight, Vector2.down, 0.2f, tideMask);
        if (hitB.collider != null)
        {
            gMScript.EndGame();
        }

        RaycastHit2D hitClose = Physics2D.Raycast(transform.position + Vector3.down * halfHeight, Vector2.down, 4f, tideMask);
        if (hitClose.collider != null)
        {
            if (prox == false)
            {
                sFXManager.PlayClip("proximity increasing");
            }
            prox = true;
        }
        else
        {
            prox = false;
        }
    }
}
