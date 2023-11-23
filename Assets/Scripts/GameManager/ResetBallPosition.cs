using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetBallPosition : MonoBehaviour
{
    //OBSERVER function for scripts to get notified when the ball resets
    private static List<IGotReset> resetObservers = new List<IGotReset>();

    public static void AddResetObserver(IGotReset resetObserver){
        resetObservers.Add(resetObserver);
    }
    public static void RemoveResetObserver(IGotReset resetObserver){
        resetObservers.Remove(resetObserver);
    }

    public static void NotifyReset()
    {
        foreach(IGotReset resetObserver in resetObservers){
            resetObserver.OnResetNotify();
        }
    }

    [SerializeField]private Transform ball;

    [SerializeField]private bool startCountdown = false;
    [SerializeField]private float countDown;
    private float countDownCounter;

    [SerializeField]private TextMeshProUGUI timerBox;

    private void Start() {
        ResetCountdown();
    }
    
    public void ResetPos(){
        ball.transform.position = new Vector3(0,0);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Start timer to make ball start moving after timer ends
        ResetCountdown();
        startCountdown = true;

        //Notify observers that the ball has been reset or that the game has restarted
        NotifyReset();
    }

    void ThrowBall(){
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.7f, 0f)*5000);
    }

    void ResetCountdown(){
        countDownCounter = countDown;
    }

    private void Update() {
        if(startCountdown){
            countDownCounter -= Time.deltaTime;
            timerBox.text = ((int)countDownCounter+1).ToString();
            //Hold ball
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }else{
            timerBox.text = "";
        }

        if(countDownCounter <= 0 && startCountdown){
            ThrowBall();
            startCountdown = false;
        }
    }

    
}
