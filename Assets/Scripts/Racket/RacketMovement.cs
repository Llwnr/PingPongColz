using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private bool leftRacket = false;

    [SerializeField]private float moveForce;
    [SerializeField]private float maxMoveSpeed;

    private float hDir, vDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(leftRacket){
            vDir = Input.GetAxisRaw("VerticalLeft");
            hDir = Input.GetAxisRaw("HorizontalLeft");
        }else{
            vDir = Input.GetAxisRaw("Vertical");
            hDir = Input.GetAxisRaw("Horizontal");
            Debug.Log("Test3");
        }
        rb.velocity *= 0.9f;
        rb.AddForce(new Vector2(hDir, vDir) * moveForce * rb.mass);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxMoveSpeed);

        //Gradually stop when releasing keys
        if(vDir == 0) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.7f);
        if(hDir == 0) rb.velocity = new Vector2(rb.velocity.x*0.7f, rb.velocity.y);

        //Reduce horizontal velocity always
        rb.velocity = new Vector2(rb.velocity.x*0.85f, rb.velocity.y);
    }
}
