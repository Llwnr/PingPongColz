using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosion : MonoBehaviour
{
    [SerializeField]private ParticleSystem explosionPrefab;
    private ParticleSystem explosionParticle;

    private Vector2 prevPos;

    private void FixedUpdate() {
        //Since the ball is reset to center after it hits wall
        prevPos = transform.position;
    }
  
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("DeathWall")){
            if(explosionParticle != null){
                explosionParticle.transform.position = prevPos;
                explosionParticle.Play();
            }
            else{
                //Make the particle
                explosionParticle = Instantiate(explosionPrefab, prevPos, Quaternion.identity);
            }
        }
    }
}
