using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInfo : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI playerName, playerScore;
    
    public void SetData(string name, int score){
        playerName.text = name + "  :";
        playerScore.text = score.ToString();
    }
}
