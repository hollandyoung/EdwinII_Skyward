using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Variables
    public bool cameraMoveable;
    private Vector3 oldLoc;
    private float scrollScale = 1.0f;
    [SerializeField] private GameObject focalObject;
    private float yFocalPoint;
    private float xFocalPoint;
    private Rigidbody2D rb;
    [SerializeField] private float cameraSpeedAdjust;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMoveable)
        {
            if (transform.position.z <= -1 && transform.position.z >= -16)
            {
                Zoom();
            }
            else if (transform.position.z >= -1)
            {
                transform.position = new Vector3 (transform.position.x, transform.position.y, -1);
            }
            else
            {
                transform.position = new Vector3 (transform.position.x, transform.position.y, -16);
            }
            Pan();
        }
        yFocalPoint = focalObject.transform.position.y;
        xFocalPoint = focalObject.transform.position.x;
        if (rb.velocity.y <= 0.1 && rb.velocity.y != 0)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (Mathf.Abs(yFocalPoint - transform.position.y) > 0.01)
        {
            rb.velocity = new Vector2(0, cameraSpeedAdjust * (yFocalPoint - transform.position.y));
        }
        if (rb.velocity.x <= 0.1 && rb.velocity.x != 0)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (Mathf.Abs(xFocalPoint - transform.position.x) > 0.01)
        {
            rb.velocity = new Vector2(cameraSpeedAdjust * (xFocalPoint - transform.position.x), 0);
        }
    }

    void Pan()
    {
        if (Input.GetMouseButtonDown(2))
        {
            oldLoc = Input.mousePosition;
        }
        else if (Input.GetMouseButton(2))
        {
            transform.Translate((oldLoc - Input.mousePosition) * 0.001f * Mathf.Abs(transform.position.z));
            oldLoc = Input.mousePosition;
        }
    }

    void Zoom()
    {
        transform.Translate(new Vector3(0.0f, 0.0f, 1.0f) * Input.mouseScrollDelta.y * scrollScale);
    }
}