using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    [SerializeField]private TMP_InputField username, password;
    [SerializeField]private PlayersReady playersReadyManager;
    protected string saveFileName = "/UserRegistrationData.txt";
    //For verification of user 1
    public void CheckCredentialsP1(){
        if(File.Exists(Application.dataPath + saveFileName)){
            //Load the save file to an array
            string loadedData = File.ReadAllText(Application.dataPath + saveFileName);
            List<RegisterData> myLoginDatas = JsonUtility.FromJson<RegisterDataHolder>(loadedData).registerDatas.ToList();
            //Check if the login username & password matches any of the registered data
            foreach(RegisterData registerData in myLoginDatas){
                string uname = registerData.myUsername;
                string pw = registerData.myPassword;
                if(uname == username.text && pw == password.text){
                    Debug.Log("Logged in succesfully");
                    PlayerPrefs.SetString("p1Name", uname);
                    //Set player 1 as ready to start
                    playersReadyManager.SetP1Ready();
                    //Set button as logged in
                    SetAsLoggedIn();
                    return;
                }
            }
        }
        

        Debug.Log("Not registered/ Wrong login credentials");
        transform.parent.GetComponent<LoginErrorAnim>().StartShake();
    }

    //For verification of user 2
    public void CheckCredentialsP2(){
        if(File.Exists(Application.dataPath + saveFileName)){
            //Load the save file to an array
            string loadedData = File.ReadAllText(Application.dataPath + saveFileName);
            List<RegisterData> myLoginDatas = JsonUtility.FromJson<RegisterDataHolder>(loadedData).registerDatas.ToList();
            //Check if the login username & password matches any of the registered data
            foreach(RegisterData registerData in myLoginDatas){
                string uname = registerData.myUsername;
                string pw = registerData.myPassword;
                if(uname == username.text && pw == password.text){
                    Debug.Log("Logged in succesfully");
                    PlayerPrefs.SetString("p2Name", uname);
                    playersReadyManager.SetP2Ready();
                    //Set button as logged in
                    SetAsLoggedIn();
                    return;
                }
            }
        }
        Debug.Log("Not registered/ Wrong login credentials");
        transform.parent.GetComponent<LoginErrorAnim>().StartShake();
    }

    void SetAsLoggedIn() {
        //Set "Login" button as logged in
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Done";
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<Button>().interactable = false;
    }
}
