using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LastHitRacket
{
    private static GameObject lastHitRacket;

    public static void SetLastHitRacket(GameObject racket){
        lastHitRacket = racket;
    }

    public static GameObject GetLastHitRacket(){
        return lastHitRacket;
    }
}
