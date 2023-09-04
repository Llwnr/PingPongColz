using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RacketSizeIncrease", menuName = "Powerup/RacketSizeIncrease", order = 0)]
public class RacketSizeIncrease : Powerup
{
    private Vector3 origLocalScale;
    [SerializeField] private Vector3 buffedSize;
    private GameObject myTarget;
    public override void Activate(GameObject racket)
    {
        origLocalScale = racket.GetComponent<RacketDefaultValues>().GetOrigLocalScale();
        LoadInitials();
        Debug.Log("Activated powerup to: " + racket.name);
        racket.transform.localScale = buffedSize;
        myTarget = racket;
    }

    public override void Deactivate(GameObject racket)
    {
        Debug.Log("Powerup deactivated: " + racket.name);
        racket.transform.localScale = origLocalScale;
    }
}
