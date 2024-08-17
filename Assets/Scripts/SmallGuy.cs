using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGuy : MonoBehaviour
{
    Rigidbody2D rb;
    bool walking = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
        {
            rb.velocity = Vector3.right * Random.Range(-0.1f, 0.1f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    IEnumerator SwitchState()
    {
        walking = !walking;
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        SwitchState();
    }
}
