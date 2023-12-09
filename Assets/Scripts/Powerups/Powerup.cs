using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    [SerializeField]private float origDuration;

    protected GameObject ball;

    private PowerupHolder powerupHolder;

    //To remove the powerup once its deactivated
    public void SetActivatorRef(PowerupHolder powerupHolder){
        this.powerupHolder = powerupHolder;
    }
    public PowerupHolder GetActivatorRef(){
        return powerupHolder;
    }

    public float GetDuration(){
        return origDuration;
    }

    public abstract void Activate(GameObject racket);
    public abstract void Deactivate(GameObject racket);
    public abstract void PlayDeactivationAnim(GameObject racket);

    protected void LoadInitials(){
        ball = GameObject.FindWithTag("Ball");
    }
}
