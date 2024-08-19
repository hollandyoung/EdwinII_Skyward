using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class AnnoyingSlot : MonoBehaviour
{
    // Variables for external components
    private SpriteRenderer rend;
    public GameObject connection = null;
    private BuildManager buildManager;
    private SFXManager sFXManager;

    // Platform sprites
    [SerializeField] Sprite aloneSprite;
    [SerializeField] Sprite joinedSprite;

    // Instance Variables
    public bool filled;
    [SerializeField] List<string> validTypes = new List<string>();
    private bool rightSide;
    private int[] coords = new int[2];
    private string type;
    private bool initialized = false;

    // Neighbors
    GameObject left = null;
    GameObject right = null;
    GameObject up = null;
    GameObject down = null;

    // Prefabs
    [SerializeField] GameObject housePrefab;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject columnPrefab;
    [SerializeField] GameObject minePrefab;
    [SerializeField] GameObject kilnPrefab;

    private float BuildingCost;
    public GameObject Bricked;
    private Bricks Bricker;
    public float TotalBricks;

    public bool isKiln = false;
    public float kilnBoost;

    private void Awake()
    {
        buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();
        sFXManager = GameObject.Find("GameManager").GetComponent<SFXManager>();
    }

    private void Start()
    {
        Bricked = GameObject.Find("Brick Manager");
        Bricker = Bricked.GetComponent<Bricks>();

        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.enabled = false;
        filled = false;
        type = "empty";
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
            case "kiln":
                prefab = kilnPrefab;
                BuildingCost = 30.0f;
                isKiln = true;
                StartCoroutine(ProduceKilnBricks());
                break;
            case "mine":
                prefab = minePrefab;
                BuildingCost = 10.0f;
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
            sFXManager.PlayClip("place");
            type = connection.tag.ToLower();
            connection.GetComponent<House>().SetCoords(coords[0], coords[1]);
            
            buildManager.UpdateWeight(type, rightSide);
            buildManager.RefreshKilns(rightSide);
            filled = true;
            Refresh();
        }
    }
    
    public void DestroyStructure()
    {
        Destroy(connection);
        sFXManager.PlayClip("destroy");
        connection = null;
        filled = false;
        type = "empty";
        isKiln = false;
        buildManager.UpdateWeight(type, !rightSide);

        CheckNeighbors();
        if (left != null)
        {
            SendRefreshMessage(left);
        }
        if (right != null)
        {
            SendRefreshMessage(right);
        }
        if (up != null)
        {
            SendRefreshMessage(up);
        }
        if (down != null)
        {
            SendRefreshMessage(down);
        }
    }

    private void SendRefreshMessage(GameObject child)
    {
        child.transform.parent.gameObject.GetComponent<AnnoyingSlot>().Refresh();
    }

    private void AddAll()
    {
        AddValidType("column");
        AddValidType("house");
        AddValidType("platform");
        AddValidType("kiln");
        AddValidType("mine");
    }
    
    private void OnMouseOver()
    {
        string structureType = buildManager.GetBuildType();

        if (!filled)
        {
            CheckNeighbors();
            if (validTypes.Contains(structureType))
            {
                rend.enabled = true;
                if (Input.GetMouseButton(0) && initialized)
                {
                    SpawnStructure(structureType);
                    rend.enabled = false;
                }
            }
        }
        else if (buildManager.GetBuildType().Equals("destroy"))
        {
            rend.enabled = true;
        }

        if (Input.GetMouseButton(1) && filled)
        {
            DestroyStructure();
            rend.enabled = false;
        }
    }
    
    private void OnMouseExit()
    {
        rend.enabled = false;
    }

    public void SetCoords(int row, int col)
    {
        coords[0] = row;
        coords[1] = col;

        float targX;
        float targY;

        targY = 0.16f + 0.16f * row;
        targX = -0.4f + 0.16f * col;

        transform.localPosition = new Vector3(targX, targY, -0.001f);
        initialized = true;
    }
    
    private void CheckNeighbors()
    {
        validTypes.Clear();
        kilnBoost = 0;

        GameObject[,] sourceArr;
        if (rightSide)
        {
            sourceArr = buildManager.rightSide;
        }
        else
        {
            sourceArr = buildManager.leftSide;
        }

        left = null;
        if (coords[1] > 0)
        {
            if (sourceArr[coords[0], coords[1] - 1].GetComponent<AnnoyingSlot>().filled)
            {
                left = sourceArr[coords[0], coords[1] - 1].transform.GetChild(0).gameObject;

                Debug.Log("got to checking");
                switch (left.tag)
                {
                    case "Platform":
                        AddValidType("platform");
                        break;
                    case "Mine":
                        Debug.Log("Found a mine");
                        if (isKiln) {
                            Debug.Log("Tried to boost");
                            kilnBoost += 1;
                        }
                        break;
                }
            }
        }
        if (coords[1] > 1)
        {
            if (sourceArr[coords[0], coords[1] - 2].GetComponent<AnnoyingSlot>().filled)
            {
                left = sourceArr[coords[0], coords[1] - 2].transform.GetChild(0).gameObject;

                Debug.Log("got to second checking");
                switch (left.tag)
                {
                    case "Mine":
                        Debug.Log("Found a second mine");
                        if (isKiln) {
                            Debug.Log("Tried to boost 2");
                            kilnBoost += 1;
                        }
                        break;
                }
            }
        }
        if (coords[1] > 2)
        {
            if (sourceArr[coords[0], coords[1] - 3].GetComponent<AnnoyingSlot>().filled)
            {
                left = sourceArr[coords[0], coords[1] - 3].transform.GetChild(0).gameObject;

                Debug.Log("got to third checking");
                switch (left.tag)
                {
                    case "Mine":
                        Debug.Log("Found a third mine");
                        if (isKiln) {
                            Debug.Log("Tried to boost 3");
                            kilnBoost += 1;
                        }
                        break;
                }
            }
        }
        if (coords[1] > 3)
        {
            if (sourceArr[coords[0], coords[1] - 4].GetComponent<AnnoyingSlot>().filled)
            {
                left = sourceArr[coords[0], coords[1] - 4].transform.GetChild(0).gameObject;

                Debug.Log("got to fourth checking");
                switch (left.tag)
                {
                    case "Mine":
                        Debug.Log("Found a fourth mine");
                        if (isKiln) {
                            Debug.Log("Tried to boost 4");
                            kilnBoost += 1;
                        }
                        break;
                }
            }
        }

        right = null;
        if (coords[1] < sourceArr.GetLength(1) - 1)
        {
            if (sourceArr[coords[0], coords[1] + 1].GetComponent<AnnoyingSlot>().filled)
            {
                right = sourceArr[coords[0], coords[1] + 1].transform.GetChild(0).gameObject;

                switch (right.tag)
                {
                    case "Platform":
                        AddValidType("platform");
                        break;
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        }
        if (coords[1] < sourceArr.GetLength(1) - 2)
        {
            if (sourceArr[coords[0], coords[1] + 2].GetComponent<AnnoyingSlot>().filled)
            {
                right = sourceArr[coords[0], coords[1] + 2].transform.GetChild(0).gameObject;

                switch (right.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        }
        if (coords[1] < sourceArr.GetLength(1) - 3)
        {
            if (sourceArr[coords[0], coords[1] + 3].GetComponent<AnnoyingSlot>().filled)
            {
                right = sourceArr[coords[0], coords[1] + 3].transform.GetChild(0).gameObject;

                switch (right.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        }
        if (coords[1] < sourceArr.GetLength(1) - 4)
        {
            if (sourceArr[coords[0], coords[1] + 4].GetComponent<AnnoyingSlot>().filled)
            {
                right = sourceArr[coords[0], coords[1] + 4].transform.GetChild(0).gameObject;

                switch (right.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        }

        up = null;
        if (coords[0] < sourceArr.GetLength(0) - 1)
        {
            if (sourceArr[coords[0] + 1, coords[1]].GetComponent<AnnoyingSlot>().filled)
            {
                up = sourceArr[coords[0] + 1, coords[1]].transform.GetChild(0).gameObject;
                switch (up.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        }
        if (coords[0] < sourceArr.GetLength(0) - 2)
        {
            if (sourceArr[coords[0] + 2, coords[1]].GetComponent<AnnoyingSlot>().filled)
            {
                up = sourceArr[coords[0] + 2, coords[1]].transform.GetChild(0).gameObject;
                switch (up.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        }
        if (coords[0] < sourceArr.GetLength(0) - 4)
        {
            if (sourceArr[coords[0] + 4, coords[1]].GetComponent<AnnoyingSlot>().filled)
            {
                up = sourceArr[coords[0] + 4, coords[1]].transform.GetChild(0).gameObject;
                switch (up.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        }
        if (coords[0] < sourceArr.GetLength(0) - 6)
        {
            if (sourceArr[coords[0] + 6, coords[1]].GetComponent<AnnoyingSlot>().filled)
            {
                up = sourceArr[coords[0] + 6, coords[1]].transform.GetChild(0).gameObject;
                switch (up.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        }

        down = null;
        if (coords[0] > 0)
        {
            if (sourceArr[coords[0] - 1, coords[1]].GetComponent<AnnoyingSlot>().filled)
            {
                down = sourceArr[coords[0] - 1, coords[1]].transform.GetChild(0).gameObject;
                switch (down.tag)
                {
                    case "Platform":
                        AddValidType("column");
                        AddValidType("house");
                        AddValidType("kiln");
                        AddValidType("mine");
                        break;
                    case "Column":
                        AddAll();
                        break;
                    case "Mine":
                        if (isKiln)
                        {
                            kilnBoost += 1;
                        }
                        break;
                }

                if (filled && connection.CompareTag("Platform") && down.CompareTag("Column"))
                {
                    connection.GetComponent<SpriteRenderer>().sprite = joinedSprite;
                }
            }
            else if (filled && connection.CompareTag("Platform"))
            {
                connection.GetComponent<SpriteRenderer>().sprite = aloneSprite;
            }
        }
        else
        {
            AddAll();
            if (filled && connection.CompareTag("Platform"))
            {
                connection.GetComponent<SpriteRenderer>().sprite = joinedSprite;
            }
            /*else if (filled && connection.CompareTag("Platform"))
            {
                connection.GetComponent<SpriteRenderer>().sprite = aloneSprite;
            }*/
        }
        if (coords[0] > 6)
            if (sourceArr[coords[0] + 2, coords[1]].GetComponent<AnnoyingSlot>().filled)
            {
                up = sourceArr[coords[0] + 2, coords[1]].transform.GetChild(0).gameObject;
                switch (up.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        if (coords[0] > 8)
            if (sourceArr[coords[0] + 4, coords[1]].GetComponent<AnnoyingSlot>().filled)
            {
                up = sourceArr[coords[0] + 4, coords[1]].transform.GetChild(0).gameObject;
                switch (up.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        if (coords[0] > 10)
            if (sourceArr[coords[0] + 6, coords[1]].GetComponent<AnnoyingSlot>().filled)
            {
                up = sourceArr[coords[0] + 6, coords[1]].transform.GetChild(0).gameObject;
                switch (up.tag)
                {
                    case "Mine":
                    if (isKiln) {
                        kilnBoost += 1;
                    }
                        break;
                }
            }
        
    }
    
    public void SetSide(bool side)
    {
        rightSide = side;
    }

    // Returns empty if not filled, otherwise returns standardized string for type
    public string GetStructureType()
    {
        return type;
    }

    private void AddValidType(string type)
    {
        if (!validTypes.Contains(type))
        {
            validTypes.Add(type);
        }
    }

    public void Refresh()
    {
        CheckNeighbors();
        
        if (validTypes.Count == 0)
        {
            DestroyStructure();
        }
    }
    IEnumerator ProduceKilnBricks()
    {
        // Wait for 4 seconds
        while (isKiln)
        {
            yield return new WaitForSeconds(2);
            TotalBricks = Bricker.GetBrickCount();
            Bricker.SetBrickCount(TotalBricks + (kilnBoost * kilnBoost));
        }
    }
}