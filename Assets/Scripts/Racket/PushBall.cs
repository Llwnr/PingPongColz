using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    [SerializeField]private float bounceAfterPush = 0;

    public void SetPushPower(float amt){
        bounceAfterPush = amt;
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Ball")){
            StartCoroutine(IncreaseForce(other.transform.GetComponent<Rigidbody2D>()));
        }
    }

    IEnumerator IncreaseForce(Rigidbody2D rb){
        yield return new WaitForEndOfFrame();
        rb.AddForce(rb.velocity.normalized * bounceAfterPush * 300);
    }
}
