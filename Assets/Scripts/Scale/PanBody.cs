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
        if (hitL.collider != null && gMScript.GetTimerRunning())
        {
            gMScript.EndGame();
            sFXManager.PlayClip("hit wall");
        }

        RaycastHit2D hitR = Physics2D.Raycast(transform.position + Vector3.right * halfLength, Vector2.right, 0.1f, mask);
        if (hitR.collider != null && gMScript.GetTimerRunning())
        {
            gMScript.EndGame();
            sFXManager.PlayClip("hit wall");
        }

        RaycastHit2D hitB = Physics2D.Raycast(transform.position + Vector3.down * halfHeight, Vector2.down, 0.2f, tideMask);
        if (hitB.collider != null && gMScript.GetTimerRunning())
        {
            gMScript.EndGame();
        }

        RaycastHit2D hitStage3 = Physics2D.Raycast(transform.position + Vector3.down * halfHeight, Vector2.down, 4f, tideMask);
        if (hitStage3.collider != null)
        {
            sFXManager.SetStage(3);
        }
        else
        {
            RaycastHit2D hitStage2 = Physics2D.Raycast(transform.position + Vector3.down * halfHeight, Vector2.down, 8f, tideMask);
            if (hitStage2.collider != null)
            {
                sFXManager.SetStage(2);
            }
            else
            {
                sFXManager.SetStage(1);
            }
        }

        
    }
}
