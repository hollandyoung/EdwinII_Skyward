using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBody : MonoBehaviour
{
    // Variables
    [SerializeField] Transform[] positions;
    private int houseCount;
    private Camera mainCam;

    [SerializeField] GameObject housePrefab;
    [SerializeField] GameObject houseStack;
    [SerializeField] GameObject colorHousePrefab;
    [SerializeField] GameObject heavyHousePrefab;
    [SerializeField] GameObject floatHousePrefab;
    [SerializeField] GameObject growHousePrefab;

    void Start()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(houseStack, positions[i]);
        }
        houseCount = 0;
        mainCam = Camera.main;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int slot = GetClosestSlot();
            if (slot != -1)
            {
                CreateHouse("basic", slot);
            }
            else
            {
                Debug.Log("Disaster");
            }
        }
    }

    private void CreateHouse(string type, int slot)
    {
        GameObject prefab;
        type = type.ToLower();
        switch (type)
        {
            case "color":
                prefab = colorHousePrefab;
                break;
            case "heavy":
                prefab = heavyHousePrefab;
                break;
            case "float":
                prefab = floatHousePrefab;
                break;
            case "grow":
                prefab = growHousePrefab;
                break;
            default:
                prefab = housePrefab;
                break;
        }
        positions[slot].GetComponentInChildren<HouseStack>().AddHouse(prefab);
        houseCount++;
    }

    private int GetClosestSlot()
    {
        /*float minDist = (mainCam.ScreenToWorldPoint(Input.mousePosition) - positions[0].position).magnitude;
        int closest = 0;

        for (int i = 1; i < positions.Length; i++)
        {
            if ((mainCam.ScreenToWorldPoint(Input.mousePosition) - positions[i].transform.position).magnitude < minDist)
            {
                closest = i;
                minDist = (mainCam.ScreenToWorldPoint(Input.mousePosition) - positions[i].transform.position).magnitude;
            }
        }
        return closest;*/
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector3.fwd, 1.0f + mainCam.transform.position.z, 9);
        if (hit.collider != null)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if (hit.collider.transform == positions[i])
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public float GetWeight()
    {
        float weight = 0f;
        for (int i = 0; i < positions.Length; i++)
        {
            weight += positions[i].GetComponentInChildren<HouseStack>().GetWeight();
        }
        return weight;
    }

    public int GetCount()
    {
        return houseCount;
    }
}
