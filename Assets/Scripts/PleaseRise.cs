using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleaseRise : MonoBehaviour
{
    public float BaseSpeed = 10.0f;
    public float TrueSpeed;
    public Rigidbody2D rb;
    public Vector2 FixMovement;

    public GameObject Beam;
    private double tiltVelocity;
    private BeamTilt Tilt;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Tilt = Beam.GetComponent<BeamTilt>();
    }

    // Update is called once per frame
    void Update()
    {
       FixMovement = new Vector2(0,1);
        tiltVelocity = Tilt.GetBeamTiltVelocity();
    }
    void FixedUpdate(){
        MoveTide(FixMovement);
    }
    void MoveTide(Vector2 Fix){
        TrueSpeed = (float)(BaseSpeed * (tiltVelocity + 1));
        rb.velocity = Fix * TrueSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        GameOver();
    }
    void GameOver() {
        Debug.Log("The game is supposed to end but has not!");
        Debug.Log("As you were the first to notice this you have unlocked the ability to create a game over screen for free!");
    }
}

