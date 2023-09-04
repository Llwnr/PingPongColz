using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GivePoint : MonoBehaviour
{
    [SerializeField]private bool leftPlayerSide;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Ball")){
            //Increase the point
            if(leftPlayerSide){
                PointsManager.instance.GivePoint(1);                
            }else{
                PointsManager.instance.GivePoint(2);                
            }
            //Update to show in text
            PointsManager.instance.UpdateScores();

            //Then reset ball position
            GameObject.FindWithTag("GameManager").GetComponent<ResetBallPosition>().ResetPos();
        }
    }
}
