using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class AnnoyingSlot : MonoBehaviour
{
    // Variables for external components
    private SpriteRenderer rend;
    private GameObject source;
    private GameObject connection = null;
    private BuildManager buildManager;

    // Instance Variables
    public bool filled;
    private bool clicked;
    private List<string> validTypes = new List<string>();
    private bool rightSide;
    private int[] coords = new int[2];
    private int col = -1;
    private int row = -1;
    private bool initialized = false;

    // Prefabs
    [SerializeField] GameObject housePrefab;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject columnPrefab;

    private float BuildingCost;
    public GameObject Bricked;
    private Bricks Bricker;
    public float TotalBricks;

    private void Start()
    {
        Bricked = GameObject.Find("Brick Manager");
        Bricker = Bricked.GetComponent<Bricks>();

        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.enabled = false;
        //source = transform.parent.gameObject;
        buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();

        // MAKE THIS CHECK NEIGHBORS
        CheckNeighbors();
        /*switch (source.tag)
        {
            case "Column":
                if (gameObject.name == "TTerminal")
                {
                    AddAll();
                }
                break;
            case "Platform":
                if (gameObject.name == "TTerminal")
                {
                    validTypes.Add("column");
                    validTypes.Add("house");
                }
                else if (gameObject.name == "LTerminal" || gameObject.name == "RTerminal")
                {
                    validTypes.Add("platform");
                }
                break;
            case "Pan":
                AddAll();
                break;
        }*/

        /*if (source.tag.Equals("Pan"))
        {
            initialized = true;
            if (source.name.Equals("Body1"))
            {
                rightSide = false;
            }
            else
            {
                rightSide = true;
            }

            switch (gameObject.name)
            {
                case "Slot0":
                    col = 0;
                    break;
                case "Slot1":
                    col = 1;
                    break;
                case "Slot2":
                    col = 2;
                    break;
                case "Slot3":
                    col = 3;
                    break;
                case "Slot4":
                    col = 4;
                    break;
            }
        }*/
    }

    private void Update()
    {
        if (clicked && connection == null)
        {
            string structureType = buildManager.GetBuildType();
            if (validTypes.Contains(structureType))
            {
                SpawnStructure(structureType);
            }
        }

        /*if (initialized)
        {
            if (clicked && connection == null)
            {
                string structureType = buildManager.GetBuildType();
                if (validTypes.Contains(structureType))
                {
                    SpawnStructure(structureType);
                }
            }
        }
        else
        {
            if (source.GetComponent<House>().initialized)
            {
                initialized |= true;
                rightSide = source.GetComponent<House>().GetSide();
                col = source.GetComponent<House>().GetCol();

                if (gameObject.name.Equals("LTerminal"))
                {
                    col--;
                }
                else if (gameObject.name.Equals("RTerminal"))
                {
                    col++;
                }

                if (col > 4 || col < 0)
                {
                    Destroy(gameObject);
                }
            }
        }*/
    }

    private void SpawnStructure(string type)
    {
        GameObject prefab;
        type = type.ToLower();
        switch (type)
        {
            case "column":
                prefab = columnPrefab;
                BuildingCost = 1.0f;
                break;
            case "platform":
                prefab = platformPrefab;
                BuildingCost = 1.0f;
                break;
            default:
                prefab = housePrefab;
                BuildingCost = 3.0f;
                break;
        }
        TotalBricks = Bricker.GetBrickCount();
        if (TotalBricks >= BuildingCost)
        {
            Bricker.SetBrickCount(TotalBricks - BuildingCost);
            connection = Instantiate(prefab, transform);
            connection.GetComponent<House>().SetSide(rightSide);
            connection.GetComponent<House>().SetCoords(coords[0], coords[1]);
            
            buildManager.UpdateWeight(type, rightSide);
        }
    }

    /*private void AddAll()
    {
        validTypes.Add("column");
        validTypes.Add("house");
        validTypes.Add("platform");
    }*/

    private void OnMouseOver()
    {
        if (connection == null)
        {
            rend.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            clicked = true;
        }
        else
        {
            clicked = false;
        }
    }

    private void OnMouseExit()
    {
        clicked = false;
        rend.enabled = false;
    }

    public void SetCoords(int row, int col)
    {
        coords[0] = row;
        coords[1] = col;

        float targX;
        float targY;

        targY = 0.16f + 0.16f * row;
        targX = -0.32f + 0.16f * col;

        transform.localPosition = new Vector3(targX, targY, 0f);
    }

    private void CheckNeighbors()
    {
        GameObject[,] sourceArr;
        if (rightSide)
        {
            sourceArr = buildManager.rightSide;
        }
        else
        {
            sourceArr = buildManager.leftSide;
        }

        GameObject left;
        if (col > 0)
        {
            left = sourceArr[row, col - 1];
        }

        GameObject right;
        if (col < 4)
        {
            right = sourceArr[row, col + 1];
        }

        GameObject up;
        if (col > 0)
        {
            left = sourceArr[row + 1, col];
        }

        GameObject down;
        if (col > 0)
        {
            left = sourceArr[row - 1, col];
        }
    }
}
