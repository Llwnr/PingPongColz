using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketDefaultValues : MonoBehaviour
{
    private Vector3 origLocalScale;
    private Color32 origSpriteColor;
    // Start is called before the first frame update
    void Start()
    {
        origLocalScale = transform.localScale;
        origSpriteColor = GetComponent<SpriteRenderer>().color;
    }

    public Vector3 GetOrigLocalScale(){
        return origLocalScale;
    }

    public Color32 GetOrigSpriteColor(){
        return origSpriteColor;
    }
}
