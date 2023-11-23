using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]private Vector2 dir;
    private Rigidbody2D rb;
    [SerializeField]private float force, maxVelocity;
    private float extraVelocity = 0;

    [SerializeField] private ResetBallPosition resetBallPosition;

    private Vector2 lastVelocity;
    // Start is called before the first frame update

    private void Awake() {
        Application.targetFrameRate = 60;
        Debug.Log("Setting frame rate from here");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        resetBallPosition.ResetPos();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity+extraVelocity);
        lastVelocity = rb.velocity;
        Debug.Log("Max vel: " + maxVelocity + extraVelocity + " Curr vel: " + rb.velocity.magnitude);
    }

    public void SetExtraVelocity(float amt){
        extraVelocity = amt;
    }
    public void ResetExtraVelocity(){
        extraVelocity = 0;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Wall") || other.transform.CompareTag("Racket")){
            
            float speed = lastVelocity.magnitude;
            Vector2 reflectDir = Vector2.Reflect(lastVelocity, other.contacts[0].normal).normalized;
            rb.velocity = new Vector2(reflectDir.x*speed, reflectDir.y*speed);

            //If the ball goes at the same direction even after reflecting, make it go opposite direction
            if (other.transform.CompareTag("Racket") && Mathf.Sign(rb.velocity.x) == Mathf.Sign(lastVelocity.x)) {
                rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
            }

            if(other.transform.CompareTag("Racket"))    StartCoroutine(LimitAngle());
        }
    }

    //Don't let ball go too vertical
    IEnumerator LimitAngle() {
        yield return new WaitForEndOfFrame();
        Vector2 dir = rb.velocity;
        float speed = dir.magnitude;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //Convert negative angles to positive
        if (Mathf.Sign(angle) == -1) {
            angle += 360;
        }

        //For ball going right side
        if (angle > 60 && angle <= 90) {
            angle = 60;
        }
        else if (angle >= 270 && angle < 300) {
            angle = 300;
        }

        //For ball going left side
        if (angle > 240 && angle <= 270) {
            angle = 240;
        }
        else if (angle >= 90 && angle < 120) {
            angle = 120;
        }

        //Direct ball to given angle
        dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) , Mathf.Sin(angle * Mathf.Deg2Rad));
        rb.velocity = dir * speed;
    }
}
