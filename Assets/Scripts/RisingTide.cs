using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingTide : MonoBehaviour
{
    public float BaseSpeed = 10.0f;
    public Rigidbody2D rb;

    private double tiltVelocity;
    private BeamTilt Tilt;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        tiltVelocity = Tilt.GetBeamTiltVelocity();
    }
    void FixedUpdate(){
        MoveTide();
    }
    void MoveTide(){
        rb.velocity = BaseSpeed * tiltVelocity;
    }
}
