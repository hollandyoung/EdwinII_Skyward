using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTilt : MonoBehaviour
{
    private float tail;
    private float tiltAcceleration;
    private float tiltVelocity;
    private float leftWeight;
    private float rightWeight;
    private Rigidbody2D rb;
    [SerializeField] private GameObject leftPan;
    [SerializeField] private GameObject rightPan;
    private PanBody leftPanScript;
    private PanBody rightPanScript;
    [SerializeField] private float velocityAdapter;
    [SerializeField] private float accelerationAdapter;

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
        tail = tiltVelocity;
        tiltVelocity += tiltAcceleration; // Adjusts the tilt velocity by the tilt acceleration
        rb.rotation -= (float) tiltVelocity; // Tilts the beam by the tilt velocity
        // If the velocity is near zero, reset acceleration to zero
        if (Mathf.Abs(tiltVelocity) < 0.0001 || Mathf.Abs(tiltVelocity) > Mathf.Abs(tail))
        {
            SetBeamTiltAcceleration(0);
            SetBeamTiltVelocity(0);
        }
    }

    public void WeightAdded(int amount, int direction) // -1 for left, 1 for right
    {
        // Change velocity by set amount in the given direction
        tiltVelocity -= (amount * direction * velocityAdapter);
        tail = tiltVelocity;
        // Change acceleration by an amount based on the weight in the opposite direction of the velocity
        if (direction == -1)
        {
            tiltAcceleration -= (accelerationAdapter * ((1 + leftWeight) / (1 + rightWeight)));
            Debug.Log("Left");
        }
        else
        {
            tiltAcceleration += (accelerationAdapter * ((1 + rightWeight) / (1 + leftWeight)));
            Debug.Log("Right");
        }
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