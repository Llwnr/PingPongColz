using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginErrorAnim : MonoBehaviour
{
    [SerializeField]private float shakeForce, shakeDuration;
    private Vector2 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    
    public void StartShake() {
        StartCoroutine(StartShake(shakeDuration));
    }

    //Shake the box
    IEnumerator StartShake(float duration) {
        Debug.Log("Shaking");
        while(duration > 0) {
            duration -= Time.deltaTime;
            transform.position = origPos + Random.insideUnitCircle * shakeForce;
            yield return null;
        }
        transform.position = origPos;
    }
}
