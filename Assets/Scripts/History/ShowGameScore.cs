using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winBox, loseBox;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("p2Score") == 6) {
            winBox.text = PlayerPrefs.GetString("p1Name");
            loseBox.text = PlayerPrefs.GetString("p2Name");
            Debug.Log(1);
        }
        else {
            winBox.text = PlayerPrefs.GetString("p2Name");
            loseBox.text = PlayerPrefs.GetString("p1Name");
        }
    }
}
