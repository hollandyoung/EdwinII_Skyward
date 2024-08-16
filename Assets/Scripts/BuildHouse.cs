using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHouse : MonoBehaviour
{
    public GameObject Houseprefab;
    public Vector2 center;
    public float houseCountRight;
    public float houseCountLeft;

    Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void createHouse(){
        GameObject h = Instantiate (Houseprefab) as GameObject;
        h.transform.position = mousePosition;
        if (mousePosition.x > center.x){
            houseCountRight += 1;
        }
        else {
            houseCountLeft += 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;

    }
}
