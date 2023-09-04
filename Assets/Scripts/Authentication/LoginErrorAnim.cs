using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginErrorAnim : MonoBehaviour
{
    [SerializeField]private float shakeForce;
    private Vector2 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = origPos + (Random.insideUnitCircle * shakeForce);
    }
}
