using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class CreateScoreData : MonoBehaviour
{
    [SerializeField]private Transform leftScoreBox, rightScoreBox;
    [SerializeField]private GameObject scoreData;
    
    List<PointsManager.PlayerScores> ReadScoreData(){
        List<PointsManager.PlayerScores> playerScoresList = new List<PointsManager.PlayerScores>();

        PointsManager.PlayerScoresHolder playerScoresHolder;
        if(File.Exists(Application.dataPath + "/scoreSave.txt")){
            string loadedData = File.ReadAllText(Application.dataPath + "/scoreSave.txt");
            playerScoresHolder = JsonUtility.FromJson<PointsManager.PlayerScoresHolder>(loadedData);
            playerScoresList = playerScoresHolder.playerScores.ToList();
        }
        return playerScoresList;
    }

    void CreateScoreHistory(){
        List<PointsManager.PlayerScores> playerScoresList = ReadScoreData();
        for(int i=0; i<playerScoresList.Count; i++){
            //Create data containers
            GameInfo leftDataInfo = Instantiate(scoreData, Vector2.zero, Quaternion.identity).GetComponent<GameInfo>();
            leftDataInfo.transform.SetParent(leftScoreBox, false);
            GameInfo rightDataInfo = Instantiate(scoreData, Vector2.zero, Quaternion.identity).GetComponent<GameInfo>();
            rightDataInfo.transform.SetParent(rightScoreBox, false);
            //Assign the data
            leftDataInfo.SetData(playerScoresList[i].p1Name, playerScoresList[i].p1Score);
            rightDataInfo.SetData(playerScoresList[i].p2Name, playerScoresList[i].p2Score);
        }
    }

    private void Start() {
        CreateScoreHistory();
    }
}
