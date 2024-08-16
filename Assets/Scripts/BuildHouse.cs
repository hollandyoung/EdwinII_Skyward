using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHouse : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject Houseprefab;
    [SerializeField] GameObject ColorHouseprefab;
    [SerializeField] GameObject HeavyHouseprefab;
    [SerializeField] GameObject FloatHouseprefab;
    [SerializeField] GameObject GrowHouseprefab;

    Vector2 center;
    Vector2 mousePosition;
    /*
    private void CreateHouse(string type, Transform pos)
    {
        GameObject prefab;
        switch (type)
        {
            case "color":
                prefab = ColorHouseprefab;
                break;
            case "heavy":
                prefab = HeavyHouseprefab;
                break;
            case "float":
                prefab = FloatHouseprefab;
                break;
            case "grow":
                prefab = GrowHouseprefab;
                break;
            default:
                prefab = Houseprefab;
                break;
        }
        Transform slot;

        GameObject a = Instantiate(prefab,);
        a.transform.position = mousePosition;
        if (mousePosition.x > center.x){
            houseCountRight += 1;
        }
        else {
            houseCountLeft += 1;
        }
    }
    
    void Update()
    {
        mousePosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0)) {
            CreateHouse();
        }

    }*/
}
