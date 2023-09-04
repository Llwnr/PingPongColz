using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseBallSpeed", menuName = "Powerup/IncreaseBallSpeed", order = 0)]
public class IncreaseBallSpeed : Powerup
{
    private GameObject ball;
    [SerializeField]private float speedIncrease;
    private GameObject racket;

    public override void Activate(GameObject racket)
    {
        LoadInitials();

        this.racket = racket;
        racket.GetComponent<SpriteRenderer>().color = Color.red;
        ball = GameObject.FindWithTag("Ball");
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        ball.GetComponent<BallMovement>().SetExtraVelocity(speedIncrease);
        racket.GetComponent<PushBall>().SetPushPower(1);
    }

    public override void Deactivate(GameObject racket)
    {
        racket.GetComponent<SpriteRenderer>().color = Color.white;
        ball.GetComponent<BallMovement>().ResetExtraVelocity();
        racket.GetComponent<PushBall>().SetPushPower(0);
    }
}
