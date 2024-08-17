using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnoyingSlot : MonoBehaviour
{
    public bool clicked;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
            Debug.Log("Click registered");
        }
        else
        {
            clicked = false;
            Debug.Log("Touching");
        }
    }

    private void OnMouseExit()
    {
        clicked = false;
    }
}
