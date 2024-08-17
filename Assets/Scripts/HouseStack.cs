using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class HouseStack : MonoBehaviour
{
    private List<GameObject> houses = new List<GameObject>();
    Transform anchorTrans;

    public void AddHouse(GameObject house)
    {
        GameObject obj = Instantiate(house);
        houses.Add(obj);
        float height = obj.GetComponent<Collider2D>().bounds.size.y;
        obj.transform.position = transform.position + new Vector3(0f, height * houses.Count, 0f);
    }

    public float GetWeight()
    {
        float weight = 0f;
        for (int i = 0; i < houses.Count; i++)
        {
            if (houses[i] != null)
            {
                string type = houses[i].GetComponent<House>().GetHouseType();

                // Change the weight modifiers to change weight of houses
                switch (type)
                {
                    case "color":
                        weight += 1.0f;
                        break;
                    case "heavy":
                        weight += 3.0f;
                        break;
                    case "float":
                        weight -= 1.0f;
                        break;
                    case "grow":
                        weight += 10;
                        break;
                    default:
                        weight += 1.0f;
                        break;
                }
            }
        }
        return weight;
    }
}
