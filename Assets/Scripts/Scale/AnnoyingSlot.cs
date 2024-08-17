using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnoyingSlot : MonoBehaviour
{
    // Variables for external components
    private SpriteRenderer rend;
    private GameObject source;
    private GameObject connection = null;
    private BuildManager buildManager;
    
    // Instance Variables
    private bool clicked;
    private List<string> validTypes = new List<string>();
    [SerializeField] bool rightSide;

    // Prefabs
    [SerializeField] GameObject housePrefab;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject columnPrefab;

    private void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.enabled = false;
        source = transform.parent.gameObject;
        buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();

        switch (source.tag)
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
        }

        if (source.tag.Equals("Pan"))
        {
            if (source.name.Equals("Body1"))
            {
                rightSide = false;
            }
            else
            {
                rightSide = true;
            }
        }
        else
        {
            rightSide = source.GetComponent<House>().GetSide();
        }
    }

    private void Update()
    {
        if (clicked && connection == null)
        {
            string structureType = buildManager.GetBuildType();
            if (validTypes.Contains(structureType))
            {
                GenerateConnection(structureType);
            }
        }
    }

    private void GenerateConnection(string type)
    {
        GameObject prefab;
        type = type.ToLower();
        switch (type)
        {
            case "column":
                prefab = columnPrefab;
                break;
            case "platform":
                prefab = platformPrefab;
                break;
            default:
                prefab = housePrefab;
                break;
        }
        connection = Instantiate(prefab, transform);
        connection.GetComponent<House>().SetSide(rightSide);
        buildManager.UpdateWeight(type, rightSide);
    }

    private void AddAll()
    {
        validTypes.Add("column");
        validTypes.Add("house");
        validTypes.Add("platform");
    }

    private void OnMouseOver()
    {
        if (connection == null)
        {
            rend.enabled = true;
        }

        if (Input.GetMouseButtonDown(0))
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
}
