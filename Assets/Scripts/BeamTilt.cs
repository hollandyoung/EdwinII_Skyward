using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTilt : MonoBehaviour
{
    private float tiltAcceleration;
    private float tiltVelocity;
    private float leftWeight;
    private float rightWeight;
    private Rigidbody2D rb;
    [SerializeField] private GameObject leftPan;
    [SerializeField] private GameObject rightPan;
    private PanBody leftPanScript;
    private PanBody rightPanScript;
    private float accelerationAdjust = 0.000001f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = 0;
        tiltAcceleration = 0;
        leftPanScript = leftPan.GetComponent<PanBody>();
        rightPanScript = rightPan.GetComponent<PanBody>();
    }

    // Update is called once per frame
    void Update()
    {
        leftWeight = leftPanScript.GetWeight();
        rightWeight = rightPanScript.GetWeight();
        tiltAcceleration = (float) ((rightWeight - leftWeight) * accelerationAdjust); // Changes the acceleration of the beam
        tiltVelocity += tiltAcceleration; // Adjusts the tilt velocity by the tilt acceleration
        rb.rotation -= (float) tiltVelocity; // Tilts the beam by the tilt velocity
    }

    public float GetBeamTilt()
    {
        return rb.rotation;
    }
    void SetBeamTilt(float beamTilt)
    {
        rb.rotation = beamTilt;
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