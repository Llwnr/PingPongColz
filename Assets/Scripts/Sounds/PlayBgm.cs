using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayBgm : MonoBehaviour
{
    [SerializeField] private EventReference bgm;
    private void Awake() {
        SoundPlayer.PlaySound(bgm);
    }

    private void OnDisable() {
        
    }
}
