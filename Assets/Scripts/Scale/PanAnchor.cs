using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAnchor : MonoBehaviour
{
    [SerializeField] Transform anchorTrans;

    void Update()
    {
        transform.position = anchorTrans.position;
    }
}
