using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTilt : MonoBehaviour
{
    private float tiltAcceleration;
    private float tiltVelocity;
    private float leftWeight;
    private float rightWeight;
    private Rigidbody2D rigidbody;
    private GameObject leftPan;
    private GameObject rightPan;
    private PanBody leftPanScript;
    private PanBody rightPanScript;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.rotation = 0;
        tiltAcceleration = 0;
        leftPanScript = leftPan.GetComponent<PanBody>();
        rightPanScript = rightPan.GetComponent<PanBody>();
    }

    // Update is called once per frame
    void Update()
    {
        leftWeight = leftPanScript.GetWeight();
        rightWeight = rightPanScript.GetWeight();
        tiltAcceleration = (rightWeight - leftWeight)/(rightWeight + leftWeight); // Changes the acceleration of the beam
        tiltVelocity += tiltAcceleration; // Adjusts the tilt velocity by the tilt acceleration
        rigidbody.rotation += (float) tiltVelocity; // Tilts the beam by the tilt velocity
    }

    public float GetBeamTilt()
    {
        return rigidbody.rotation;
    }
    void SetBeamTilt(float beamTilt)
    {
        rigidbody.rotation = beamTilt;
    }

    public float GetBeamTiltVelocity()
    {
        return tiltVelocity;
    }
    void SetBeamTiltVelocity(float beamTiltVelocity)
    {
        tiltVelocity = beamTiltVelocity;
    }

    public float GetBeamTiltAcceleration()
    {
        return tiltAcceleration;
    }
    void SetBeamTiltAcceleration(float beamTiltAcceleration)
    {
        tiltAcceleration = beamTiltAcceleration;
    }
}