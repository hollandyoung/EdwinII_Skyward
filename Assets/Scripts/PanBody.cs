using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanBody : MonoBehaviour
{
    // Variables
    public Transform[] slots;
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
        slots = new Transform[2];
        slots[0].position = transform.position - new Vector3 (-2.0f, 0, 0);
        slots[1].position = transform.position - new Vector3(2.0f, 0, 0);
    }

    private void OnMouseOver()
    {
        Debug.Log("Working");
        if (Input.GetMouseButtonDown(0))
        {
            CreateHouse("basic", slots[GetFirstSlot()]);
        }
    }

    private void CreateHouse(string type, Transform pos)
    {
        GameObject prefab;
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

        GameObject a = Instantiate(prefab, pos);
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
