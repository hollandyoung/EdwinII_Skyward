using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class HouseStack : MonoBehaviour
{
    /*private GameObject beam;
    private BeamTilt beamScript;
    public List<GameObject> houses = new List<GameObject>();
    Transform anchorTrans;

    void Start()
    {
        beam = GameObject.Find("Beam");
        beamScript = beam.GetComponent<BeamTilt>();
    }

    public void AddHouse(GameObject house, string panName)
    {
        GameObject obj = Instantiate(house, transform);
        houses.Add(obj);
        float height = obj.GetComponent<Collider2D>().bounds.size.y;
        obj.transform.position += new Vector3(0f, height * houses.Count, 0f);

        if (panName == "Body2")
        {
            beamScript.WeightAdded(house.GetComponent<House>().GetWeight(), -1);
        }
        else
        {
            beamScript.WeightAdded(house.GetComponent<House>().GetWeight(), 1);
            Debug.Log(panName);
        }
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
    }*/
}
