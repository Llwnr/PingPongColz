using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayOnCollision : MonoBehaviour
{
    [SerializeField]private EventReference sfx;
    //Play sound when hitting objects with these tags:
    [SerializeField]private List<string> colliderTags = new List<string>();
    
    private void OnCollisionEnter2D(Collision2D other) {
        for(int i=0; i<colliderTags.Count; i++){
            if(other.transform.CompareTag(colliderTags[i])){
                SoundPlayer.PlaySound(sfx);
                return;
            }
        }
    }
}
