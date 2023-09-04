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

        //Don't let ball direction be too vertical
        //ManageDirection();
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
        }
    }

    void ManageDirection(){
        Vector2 ballDir = rb.velocity.normalized;
        //Convert direction into angle
        float myAngle = Mathf.Atan2(ballDir.y, ballDir.x)*Mathf.Rad2Deg;
        if(myAngle > -30 && myAngle < 30 || myAngle > 150 && myAngle < 210) return;
        //Don't let ball be too vertical
        float angleA = 70, angleB = 110;
        if(myAngle < -angleA && myAngle > -90){
            myAngle = -angleA;
        }
        if(myAngle < -90 && myAngle > -angleB){
            myAngle = -angleB;
        }
        if(myAngle > angleA && myAngle < 90){
            myAngle = angleA;
        }
        if(myAngle > 90 && myAngle < angleB){
            myAngle = angleB;
        }

        //Convert the angle to velocity
        float speed = rb.velocity.magnitude;
        Vector2 newDir;
        newDir.x = Mathf.Cos(myAngle*Mathf.Deg2Rad);
        newDir.y = Mathf.Sign(myAngle*Mathf.Deg2Rad);
        rb.velocity = newDir*speed;
    }


}
