using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleaseRise : MonoBehaviour
{
    public GameObject GameManager;
    private GameManager GameMan;

    public float BaseSpeed = .1f;
    public float TrueSpeed = 0.0f;
    public Rigidbody2D rb;
    public Vector2 FixMovement;

    public GameObject Beam;
    private double tiltVelocity;
    private BeamTilt Tilt;

    public bool ScaleTide = true;
    public float Tidescale = 1.0f;
    public float TideScaleSpeed = 1.08f;

    public bool TideWavy = true;
    public float TideDirection;

    public float FixFloat;

    public float FixMovementMore; 
    public float WaveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Beam = GameObject.Find("Beam");
        GameManager = GameObject.Find("GameManager");
        GameMan = GameManager.GetComponent<GameManager>();
        rb = this.GetComponent<Rigidbody2D>();
        Tilt = Beam.GetComponent<BeamTilt>();
        StartCoroutine(TideScale());
        StartCoroutine(WavyTide());
        FixMovement = new Vector2(0,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 40) {
            transform.Translate(-80, 0, 0);
        }
        tiltVelocity = Tilt.GetBeamTiltVelocity();
    }
    void FixedUpdate(){
        if(GameMan.GetTimerRunning() == true)
        {
            MoveTide(FixMovement);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3 (0, -50, 0), 15 * Time.deltaTime);
        }
    }
    void MoveTide(Vector2 Fix){
        FixFloat = (float)tiltVelocity;
        TrueSpeed = (float)Mathf.Abs(BaseSpeed * (FixFloat + 1));
        FixMovementMore = (TrueSpeed * Tidescale * Time.deltaTime * 60);
        rb.velocity = new Vector2(WaveSpeed, FixMovementMore * TideDirection) ;
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

