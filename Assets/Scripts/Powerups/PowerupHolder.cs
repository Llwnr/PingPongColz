using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHolder : MonoBehaviour, IGotReset
{
    //Each racket will have this script
    [SerializeField]private List<Powerup> myPowerups = new List<Powerup>();
    private List<float> powerupDuration = new List<float>();

    private void Start() {
        SubscribeToResetObserver();
    }

    private void OnDisable() {
        ResetBallPosition.RemoveResetObserver(this);
    }

    private void Update() {
        RunPowerupsUpdateFunction();
    }

    //Manage Observer
    void SubscribeToResetObserver(){
        ResetBallPosition.AddResetObserver(this);
    }

    public void OnResetNotify(){
        RemoveAllPowerups();
    }
    
    public void GivePowerupToRacket(Powerup powerup){
        //If there is no powerup of the same kind then add it
        if(!myPowerups.Contains(powerup)){
            int index = myPowerups.Count;
            myPowerups.Add(powerup);
            myPowerups[index].SetActivatorRef(this);
            myPowerups[index].Activate(gameObject);
            //Set duration
            powerupDuration.Add(powerup.GetDuration());
        }
        //If there already exists that powerup then just activate it
        else{
            int index = myPowerups.IndexOf(powerup);
            myPowerups[index].Activate(gameObject);
            powerupDuration[index] = myPowerups[index].GetDuration();
        }
    }

    private void RemovePowerupFromRacket(int index){
        myPowerups[index].Deactivate(gameObject);
        myPowerups.RemoveAt(index);
        powerupDuration.RemoveAt(index);
    }

    void RemoveAllPowerups(){
        for(int i=0; i<myPowerups.Count; i++){
            RemovePowerupFromRacket(i);
            i--;
        }
    }

    //Since scriptable object cannot run Update() function, need to do it manually
    void RunPowerupsUpdateFunction(){
        int myPowerupsCount = myPowerups.Count;
        for(int i=0; i<powerupDuration.Count; i++){
            powerupDuration[i] -= Time.deltaTime;
            if(powerupDuration[i] <= 0){
                RemovePowerupFromRacket(i);
                i--;
            }
        }
    }

    //MANAGE OBSERVER
    
}
