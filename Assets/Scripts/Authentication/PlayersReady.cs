using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersReady : MonoBehaviour
{
    private bool p1Ready, p2Ready = false;
    
    public void SetP1Ready(){
        p1Ready = true;
    }

    public void SetP2Ready(){
        p2Ready = true;
    }

    private void Update() {
        if(p1Ready && p2Ready){
            //Start countdown or sth

            //Load level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
