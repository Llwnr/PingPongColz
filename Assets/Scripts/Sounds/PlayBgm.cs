using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayBgm : MonoBehaviour
{
    [SerializeField] private EventReference bgm;
    private EventInstance currentMusic;
    private void Awake() {
        currentMusic = RuntimeManager.CreateInstance(bgm);
        currentMusic.start();
    }

    private void OnDisable() {
        currentMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
