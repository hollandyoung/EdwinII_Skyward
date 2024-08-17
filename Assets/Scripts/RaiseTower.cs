using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseTower : MonoBehaviour
{
    public GameObject TowerBuilder;
    private CreateTower Builder;
    public float Height;
    public float Yscaling = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        TowerBuilder = GameObject.Find("Edwin Manager");
        Builder = TowerBuilder.GetComponent<CreateTower>();
        //rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Height = (Builder.GetNumberOfSegments() - 13);
        transform.position = new Vector3(0, (float)(Height * Yscaling), 0 );
    }
}
