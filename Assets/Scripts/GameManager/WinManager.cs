using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour {
    private PointsManager pointsManager;
    // Start is called before the first frame update
    void Start() {
        pointsManager = GameObject.FindWithTag("GameManager").GetComponent<PointsManager>();
    }

    // Update is called once per frame
    void Update() {
        if(pointsManager.GetPlayerPointData(1).playerScore > 5 || pointsManager.GetPlayerPointData(2).playerScore > 5){
            //Play some win animation
            //Then go to new scene to choose play again or main menu
            Debug.Log("You won");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
