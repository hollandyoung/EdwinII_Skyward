using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnoyingSlot : MonoBehaviour
{
    public bool clicked;
    [SerializeField] string slotType;
    [SerializeField] PanBody panBody;

    private void Start()
    {
        //slotType = "";
    }

    private void Update()
    {
        if (clicked && slotType.Equals("column"))
        {
            if (panBody == null)
            {
                Debug.Log("Disaster");
            }
            panBody.CreateHouse("column", transform);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }
        else
        {
            clicked = false;
        }
    }

    private void OnMouseExit()
    {
        clicked = false;
    }

    public void SetType(string type)
    {
        slotType = type;
    }

    public void SetPanBody(PanBody other)
    {
        panBody = other;
    }
}
