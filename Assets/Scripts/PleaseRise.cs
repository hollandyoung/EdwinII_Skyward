using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleaseRise : MonoBehaviour
{
    public GameObject GameManager;
    private GameManager GameMan;

    public float BaseSpeed = 10.0f;
    public float TrueSpeed;
    public Rigidbody2D rb;
    public Vector2 FixMovement;

    public GameObject Beam;
    private double tiltVelocity;
    private BeamTilt Tilt;

    public bool ScaleTide = true;
    public float Tidescale = 1.0f;

    public float FixFloat;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        GameMan = GameManager.GetComponent<GameManager>();
        rb = this.GetComponent<Rigidbody2D>();
        Tilt = Beam.GetComponent<BeamTilt>();
        StartCoroutine(Tidescale());
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
        rb.velocity = Fix * TrueSpeed * Tidescale;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        GameOver();
    }
    void GameOver() {
        GameMan.EndGame();
    }
        
    IEnumerator TowerTest()
    {
        while (ScaleTide) {
       //Wait for 1 seconds
        yield return new WaitForSeconds(10);
        Tidescale *= 1.2
        
        }
    }

}

