using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingEdwin : MonoBehaviour
{
    public GameObject EdwinCreator;
    private CreateTower CrTower;
    private float Segments;

    public float DeLoadGap;

    // Start is called before the first frame update
    void Start()
    {
        EdwinCreator = GameObject.Find("Edwin Manager");
        CrTower = EdwinCreator.GetComponent<CreateTower>();
    }

    // Update is called once per frame
    void Update()
    {
        Segments = CrTower.GetNumberOfSegments();
        if (Segments - (this.transform.position.y / .8) > DeLoadGap) {
            Destroy(this.gameObject);
        }
    }
}
