using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBody : MonoBehaviour
{
    // Variables
    private GameObject[] slots;
    [SerializeField] Transform[] positions;
    private int houseCount;

    [SerializeField] GameObject housePrefab;
    [SerializeField] GameObject colorHousePrefab;
    [SerializeField] GameObject heavyHousePrefab;
    [SerializeField] GameObject floatHousePrefab;
    [SerializeField] GameObject growHousePrefab;

    // Start is called before the first frame update
    void Start()
    {
        slots = new GameObject[2];
        houseCount = 0;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int slot = GetFirstSlot();
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

        slots[slot] = Instantiate(prefab);
        slots[slot].transform.position = positions[slot].position;
        houseCount++;
    }

    private int GetFirstSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    public float GetWeight()
    {
        float weight = 0f;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                string type = slots[i].gameObject.GetComponent<House>().GetHouseType();

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
                        weight += houseCount / 10;
                        break;
                    default:
                        weight += 1.0f;
                        break;
                }
            }
        }
        return weight;
    }

    public int GetCount()
    {
        return houseCount;
    }
}
