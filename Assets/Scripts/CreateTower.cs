using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public GameObject TowerPrefab;
    public bool MakeTower = true;
    public float centerX = 0;
    public float StartY = 0;
    public float Yscaling = 10;
    public float NumberOfSegments = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TowerTest());
    }

    IEnumerator TowerTest()
    {
        while (MakeTower) {
       //Wait for 1 seconds
        yield return new WaitForSeconds(1);
        GenerateTower();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateTower()
    {
        //a = new gameObject Instantiate(TowerPrefab);
        Instantiate(TowerPrefab, new Vector3(centerX, StartY + (Yscaling * NumberOfSegments), 0), Quaternion.identity);
        NumberOfSegments += 1;
    }
}
