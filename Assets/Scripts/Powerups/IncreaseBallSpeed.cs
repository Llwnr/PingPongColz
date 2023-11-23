using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseBallSpeed", menuName = "Powerup/IncreaseBallSpeed", order = 0)]
public class IncreaseBallSpeed : Powerup
{
    [SerializeField]private float speedIncrease, pushPower;//Percentage of extra speed. 10 means 10percent extra speed when ball collides

    public override void Activate(GameObject racket)
    {
        LoadInitials();

        ball.GetComponent<SpriteRenderer>().color = Color.red;
        ball.GetComponent<BallMovement>().SetExtraVelocity(speedIncrease);
        ball.GetComponent<PushBall>().SetPushPower(pushPower);
    }

    public override void Deactivate(GameObject racket)
    {
        ball.GetComponent<SpriteRenderer>().color = Color.white;
        ball.GetComponent<BallMovement>().ResetExtraVelocity();
        ball.GetComponent<PushBall>().SetPushPower(0);
    }
}
