using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject bricker;
    private Bricks brick;
    public float waitTime = 4.0f;
    public bool makeBricks = true;

    public bool isShaper = false;
    public float Xcoord;
    public float Ycoords;
    // Variables
    public int[] coords = new int[2];

    void Start()
    {
        bricker = GameObject.Find("Brick Manager");
        brick = bricker.GetComponent<Bricks>();
        transform.Translate(Vector3.forward * 0.001f);
        StartCoroutine(ProduceBricks());
        if (isShaper) {
            StartCoroutine(findMines());
        }
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
    IEnumerator findMines() {
        yield return new WaitForSeconds(1);
    }

    public void SetCoords(int row, int col)
    {
        coords[0] = row;
        coords[1] = col;
    }
}
