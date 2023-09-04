using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAsLastHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Ball")){
            LastHitRacket.SetLastHitRacket(gameObject);
        }
    }
}
