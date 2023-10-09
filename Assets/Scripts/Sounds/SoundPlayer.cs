using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public static class SoundPlayer
{
    public static void PlaySound(EventReference sfx){
        RuntimeManager.PlayOneShot(sfx);
    }
}
