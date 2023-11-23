using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayOnHover : MonoBehaviour
{
    [SerializeField] private EventReference sfx;
    
    public void PlaySound() {
        SoundPlayer.PlaySound(sfx);
    }
}
