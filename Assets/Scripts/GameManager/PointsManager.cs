using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI leftTextbox, rightTextbox;
    //Singleton class
    public static PointsManager instance{get; private set;}
    private void Awake() {
        if(instance != null){
            Debug.LogError("More than one points manager");
            return;
        }else{
            instance = this;
        }
    }

    public struct PlayerPoint{
        public string playerName;
        public int playerScore{get; private set;}

        public void IncreaseScore(){
            this.playerScore++;
        }

        public void ResetScore(){
            this.playerScore = 0;
            PointsManager.instance.UpdateScores();
        }

        public PlayerPoint(string playerName){
            this.playerName = playerName;
            this.playerScore = 0;
        }
    } 
    private PlayerPoint p1, p2;
    
    // Start is called before the first frame update
    void Start()
    {
        //Create two player point for two players
        p1 = new PlayerPoint(PlayerPrefs.GetString("p1Name"));
        p2 = new PlayerPoint(PlayerPrefs.GetString("p2Name"));
    }
    
    public void GivePoint(int player){
        if(player == 1){
            p1.IncreaseScore();
        }else{
            p2.IncreaseScore();
        }
    }

    public PlayerPoint GetPlayerPointData(int player){
        if(player == 1){
            return p1;
        }else{
            return p2;
        }
    }

    private void Update() {
        //Check for win
        if(p1.playerScore > 5 || p2.playerScore > 5){
            //Save score history of who won against who before resetting scores
            SaveScoreHistory();
            //Reset scores
            p1.ResetScore();
            p2.ResetScore();
        }
    }

    public void UpdateScores(){
        leftTextbox.text = PointsManager.instance.GetPlayerPointData(1).playerScore.ToString();
        rightTextbox.text = PointsManager.instance.GetPlayerPointData(2).playerScore.ToString();
    }

    void SaveScoreHistory(){
        PlayerScoresHolder playerScoresHolder;
        List<PlayerScores> playerScoresList;
        //Load the saved file data to update it
        if(File.Exists(Application.dataPath + "/scoreSave.txt")){
            string loadedData = File.ReadAllText(Application.dataPath + "/scoreSave.txt");
            playerScoresHolder = JsonUtility.FromJson<PlayerScoresHolder>(loadedData);
            playerScoresList = playerScoresHolder.playerScores.ToList();
        }else{
            playerScoresHolder = new PlayerScoresHolder();
            playerScoresList = new List<PlayerScores>();
        }

        PlayerScores newPlayerScores = new PlayerScores{
            p1Name = p1.playerName,
            p1Score = p1.playerScore,

            p2Name = p2.playerName,
            p2Score = p2.playerScore
        };
        //Add the new score data to the array
        playerScoresList.Add(newPlayerScores);
        //Set the updated array into playerScoresHolder(which is the main save file)
        playerScoresHolder.playerScores = playerScoresList.ToArray();

        //Now save the file
        SaveScoreOfPlayer(playerScoresHolder);

        void SaveScoreOfPlayer(PlayerScoresHolder player){
            string json = JsonUtility.ToJson(player);
            File.WriteAllText(Application.dataPath + "/scoreSave.txt", json);
        }
    }

    [System.Serializable]
    public class PlayerScores{
        public string p1Name, p2Name;
        public int p1Score, p2Score;
    }

    public class PlayerScoresHolder{
        public PlayerScores[] playerScores;
    }
}
