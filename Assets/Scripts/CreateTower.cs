using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public GameObject TowerPrefab;
    public GameObject Bricked;
    private Bricks Bricker;
    public bool MakeTower = true;
    public float centerX = 0;
    public float StartY = 0;
    public float Yscaling = 10;
    public float NumberOfSegments = 0;
    public float TotalBricks;
    public float TowerCost = 5;
    // Start is called before the first frame update
    void Start()
    {
        Bricked = GameObject.Find("Brick Manager");
        Bricker = Bricked.GetComponent<Bricks>();
        StartCoroutine(TowerTest());
        BaseTower();
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
        //if (NumberOfSegments >= 12) {
        //    MakeTower = false;
        //}
    }
    void BaseTower()
    {
        while (NumberOfSegments <= 12) {
        GenerateTower();
        }
    }
    public void GenerateTower()
    {
        //a = new gameObject Instantiate(TowerPrefab);
        TotalBricks = Bricker.GetBrickCount();
        if (TotalBricks > TowerCost){
            Bricker.SetBrickCount(TotalBricks - TowerCost);
        }
        Instantiate(TowerPrefab, new Vector3(centerX, StartY + (Yscaling * NumberOfSegments), 0), Quaternion.identity);
        NumberOfSegments += 1;
    }
    public float GetNumberOfSegments()
    {
        return NumberOfSegments;
    }
}
