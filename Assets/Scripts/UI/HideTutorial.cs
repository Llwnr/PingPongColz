using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTutorial : MonoBehaviour
{
    private float duration;
    // Start is called before the first frame update
    void Start()
    {
        duration = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if(duration <= 0) {
            Destroy(gameObject);
        }
    }
}
