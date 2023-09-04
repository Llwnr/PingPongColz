using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGiver : MonoBehaviour
{
    [SerializeField]private Powerup myPowerup;
    
    //To get the powerup at the creation of the powerup gameobject
    public void GivePowerup(Powerup powerup){
        myPowerup = powerup;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //When ball hits the powerup, give the powerup to the racket that last threw the ball
        if(other.transform.CompareTag("Ball")){
            LastHitRacket.GetLastHitRacket().GetComponent<PowerupHolder>().GivePowerupToRacket(myPowerup);
            Destroy(gameObject);
        }
    }
}
