using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBody : MonoBehaviour
{
    // Variables
    private GameObject[] slots;
    private int houseCount;
    private float weight;

    [SerializeField] GameObject housePrefab;
    [SerializeField] GameObject colorHousePrefab;
    [SerializeField] GameObject heavyHousePrefab;
    [SerializeField] GameObject floatHousePrefab;
    [SerializeField] GameObject growHousePrefab;

    // Start is called before the first frame update
    void Start()
    {
        slots = new GameObject[2];
        slots[0].transform.position = transform.position - new Vector3 (-2.0f, 0, 0);
        slots[1].transform.position = transform.position - new Vector3(2.0f, 0, 0);
        houseCount = 0;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int slot = GetFirstSlot();
            if (slot == -1)
            {
                Debug.Log("Disaster");
            }
            else
            {
                Debug.Log("Slot num: " + slot);
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
        return weight;
    }

    public int GetCount()
    {
        return houseCount;
    }
}
