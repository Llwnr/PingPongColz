using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI p1Box, p2Box;
    // Start is called before the first frame update
    void Start()
    {
        p1Box.text = PlayerPrefs.GetString("p1Name");
        p2Box.text = PlayerPrefs.GetString("p2Name");
        if (PlayerPrefs.GetInt("p1Score") == 6) p1Box.text += " has won";
        else p2Box.text += " has won";
    }
}
