using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    [SerializeField]private float duration;

    private PowerupHolder powerupHolder;

    //To remove the powerup once its deactivated
    public void SetActivatorRef(PowerupHolder powerupHolder){
        this.powerupHolder = powerupHolder;
    }
    public PowerupHolder GetActivatorRef(){
        return powerupHolder;
    }

    public float GetDuration(){
        return duration;
    }

    public abstract void Activate(GameObject racket);
    public abstract void Deactivate(GameObject racket);

    protected void LoadInitials(){
        
    }
}
