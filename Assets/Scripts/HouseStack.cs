using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseStack : MonoBehaviour
{
    private List<GameObject> houses = new List<GameObject>();
    Transform anchorTrans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddHouse(GameObject house)
    {
        houses.Add(house);
    }
}
