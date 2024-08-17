using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Variables
    public bool cameraMoveable;
    private Vector3 oldLoc;
    private float scrollScale = 1.0f;
    [SerializeField] private GameObject yFocalObject;
    private float yFocalPoint;

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
        //y
        //gameObject.transform.Translate
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
