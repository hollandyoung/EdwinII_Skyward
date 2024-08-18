using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject bricker;
    private Bricks brick;
    public float waitTime = 4.0f;
    public bool makeBricks = true;

    // Variables
    private int[] coords = new int[2];

    void Start()
    {
        bricker = GameObject.Find("Brick Manager");
        brick = bricker.GetComponent<Bricks>();
        StartCoroutine(ProduceBricks());
    }

    IEnumerator ProduceBricks()
    {
        // Wait for 4 seconds
        while (makeBricks)
        {
            yield return new WaitForSeconds(waitTime);
            brick.AddBrickCount();
        }
    }

    public void SetCoords(int row, int col)
    {
        coords[0] = row;
        coords[1] = col;
    }
}
