using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBody : MonoBehaviour
{
    // Variables
    [SerializeField] Transform[] positions;
    private int houseCount;
    private Camera mainCam;

    // Prefabs
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int slot = CheckSlotsClicked();
            if (slot != -1)
            {
                CreateHouse("basic", slot);
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

    private int CheckSlotsClicked()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].gameObject.GetComponent<AnnoyingSlot>().clicked)
            {
                return i;
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
