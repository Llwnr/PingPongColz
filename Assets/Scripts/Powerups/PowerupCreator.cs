using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCreator : MonoBehaviour, IGotReset
{
    [SerializeField]private GameObject powerupTrigger, powerupHolder;
    private PowerupGiver powerupGiver;
    [SerializeField]private float durationForPowerup;
    private float durationCount;

    [SerializeField]private List<Powerup> allPowerups = new List<Powerup>();
    
    private void Start() {
        ResetDuration();
        ResetBallPosition.AddResetObserver(this);
    }

    private void OnDisable() {
        ResetBallPosition.RemoveResetObserver(this);
    }

    private void Update() {
        //If a powerup exists don't do anything
        if(GameObject.FindWithTag("Powerup") != null) return;
        durationCount -= Time.deltaTime;
        if(durationCount <= 0){
            CreatePowerup();
            ResetDuration();
        }
    }

    void ResetDuration(){
        durationCount = durationForPowerup;
    }

    void CreatePowerup(){
        //Make a random powerup
        int index = Random.Range(0, allPowerups.Count);
        powerupGiver = Instantiate(powerupTrigger, Vector3.zero, Quaternion.identity).GetComponent<PowerupGiver>();
        powerupGiver.GivePowerup(allPowerups[index]);
        
        powerupGiver.transform.SetParent(powerupHolder.transform, false);
    }

    //Reset creation duration when game resets
    public void OnResetNotify()
    {
        ResetDuration();
        //Also delete created powerups
        if(powerupGiver) Destroy(powerupGiver.gameObject);
    }
}
