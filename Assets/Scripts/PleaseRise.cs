using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleaseRise : MonoBehaviour
{
    public GameObject GameManager;
    private GameManager GameMan;

    public float BaseSpeed = .05f;
    public float TrueSpeed;
    public Rigidbody2D rb;
    public Vector2 FixMovement;

    public GameObject Beam;
    private double tiltVelocity;
    private BeamTilt Tilt;

    public bool ScaleTide = true;
    public float Tidescale = 1.0f;
    public float TideScaleSpeed = 1.4f;

    public bool TideWavy = true;
    public float TideDirection;

    public float FixFloat;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        GameMan = GameManager.GetComponent<GameManager>();
        rb = this.GetComponent<Rigidbody2D>();
        Tilt = Beam.GetComponent<BeamTilt>();
        StartCoroutine(TideScale());
        StartCoroutine(WavyTide());
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
        FixFloat = (float)tiltVelocity;
        TrueSpeed = (float)Mathf.Abs(BaseSpeed * (FixFloat + 1));
        rb.velocity = Fix * TrueSpeed * Tidescale * TideDirection;
    }
    /*private void OnCollisionEnter2D(Collision2D collision) {
        GameOver();
    }
    void GameOver() {
        GameMan.EndGame();
    }*/
        
    IEnumerator TideScale()
    {
        // Wait for 1 second
        while (ScaleTide)
        {
            yield return new WaitForSeconds(10);
            Scaling();
        }
    }
    IEnumerator WavyTide()
    {
        while (TideWavy)
        {
            TideDirection = 2;
            yield return new WaitForSeconds(1);
            TideDirection = -1;
            yield return new WaitForSeconds(1);
        }
    }

    void Scaling()
    {
        Tidescale = (Tidescale * TideScaleSpeed);
    }

}

