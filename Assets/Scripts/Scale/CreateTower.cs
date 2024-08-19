using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateTower : MonoBehaviour
{
    public GameObject TowerPrefab;
    public GameObject Bricked;
    private Bricks Bricker;
    public bool MakeTower = true;
    public float centerX = 0;
    public float StartY = -13.4f;
    public float Yscaling = .8f;
    public float NumberOfSegments = 0;
    public float TotalBricks;
    public float TowerCost = 5;
    public bool CanBuild;

    public TextMeshProUGUI TowerCostDisplay;
    public bool BaseTowering = true;
    public float AdditionalCost;
    // Start is called before the first frame update
    void Start()
    {
        TowerCostDisplay.text = (5 + "");
        Bricked = GameObject.Find("Brick Manager");
        Bricker = Bricked.GetComponent<Bricks>();
        //StartCoroutine(TowerTest());
        BaseTower();
    }

    IEnumerator TowerTest()
    {
        while (MakeTower) {
       //Wait for 1 seconds
        yield return new WaitForSeconds(1);
        TotalBricks = Bricker.GetBrickCount();
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
        TotalBricks = Bricker.GetBrickCount();
        while (NumberOfSegments <= 12 && TotalBricks >= 5) {
        GenerateTower();
        TotalBricks = Bricker.GetBrickCount();
        }
        BaseTowering = false;
    }
    public void GenerateTower()
    {
        //a = new gameObject Instantiate(TowerPrefab);
        //Debug.Log("build");
        TotalBricks = Bricker.GetBrickCount();
        //Debug.Log(TotalBricks);
        if (TotalBricks >= TowerCost){
            Bricker.SetBrickCount(TotalBricks - TowerCost);
            Instantiate(TowerPrefab, new Vector3(centerX, StartY + (Yscaling * NumberOfSegments), 0), Quaternion.identity);
            NumberOfSegments += 1;
            if (!BaseTowering) {
                AdditionalCost += 1;
                TowerCost += 1;
                TowerCostDisplay.text = (5 + AdditionalCost + "");
            }
        }
    }
    public float GetNumberOfSegments()
    {
        return NumberOfSegments;
    }
}
