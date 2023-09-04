using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    private PointsManager pointsManager;
    // Start is called before the first frame update
    void Start()
    {
        pointsManager = GameObject.FindWithTag("GameManager").GetComponent<PointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(pointsManager.GetPlayerPointData(1).playerScore > 5 || pointsManager.GetPlayerPointData(2).playerScore > 5){
        //     Debug.Log("Someone won");
        //     //Then reset ball position
        //     GameObject.FindWithTag("GameManager").GetComponent<ResetBallPosition>().ResetPos();
        // }
    }
}
