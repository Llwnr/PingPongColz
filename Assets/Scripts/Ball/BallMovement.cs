using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]private Vector2 dir;
    private Rigidbody2D rb;
    [SerializeField]private float maxVelocity;
    private float extraVelocity = 0;

    [SerializeField] private ResetBallPosition resetBallPosition;

    private Vector2 lastVelocity;
    private float stuckDuration = 0;
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
        //Set minimum velocity
        if (rb.velocity.magnitude <= maxVelocity * 0.8f) {
            rb.velocity = rb.velocity.normalized * maxVelocity * 0.8f;
        }
        lastVelocity = rb.velocity;
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

    private void OnCollisionStay2D(Collision2D other) {
        //Just bounce the ball in another direction vertically
        if (other.transform.CompareTag("Wall")) {
            stuckDuration++;
            if (stuckDuration >= 2) {
                if(transform.position.y > 0) {
                    rb.velocity = new Vector2(rb.velocity.x, -0.7f);
                }
                else {
                    rb.velocity = new Vector2(rb.velocity.x, 0.7f);
                }
                Debug.Log("Stuck");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.transform.CompareTag("Wall")) {
            stuckDuration = 0;
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
