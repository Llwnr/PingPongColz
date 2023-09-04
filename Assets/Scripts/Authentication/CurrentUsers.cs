using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUsers : MonoBehaviour
{
    private string p1Name, p2Name;
    // Start is called before the first frame update
    void Start()
    {
        GetCurrentUsers();
    }

    void GetCurrentUsers(){
        p1Name = PlayerPrefs.GetString("p1Name");
        Debug.Log("Player 1 is: " + p1Name);
    }
}
