using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

public class LoginManager : MonoBehaviour
{
    [SerializeField]private TMP_InputField username, password;
    [SerializeField]private PlayersReady playersReadyManager;

    public void StoreCredentials(){
        string uname = username.text;
        string pw = password.text;

        //Make/Access the save file to update it
        RegisterDataHolder registerDataHolder;
        List<RegisterData> registerDataList;
        if(File.Exists(Application.dataPath + "/save.txt")){
            string loadedData = File.ReadAllText(Application.dataPath + "/save.txt");
            registerDataHolder = JsonUtility.FromJson<RegisterDataHolder>(loadedData);
            registerDataList = registerDataHolder.registerDatas.ToList();
        }else{
            registerDataHolder = new RegisterDataHolder();
            registerDataList = new List<RegisterData>();
        }
        //Write the data values and add it to the save file
        RegisterData registerData = new RegisterData{
            myUsername = uname,
            myPassword = pw
        };
        registerDataList.Add(registerData);
        //Convert the list into array and set it to register data holder's array
        registerDataHolder.registerDatas = registerDataList.ToArray();
        //Then serialize it
        string json = JsonUtility.ToJson(registerDataHolder);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }

    public void CheckCredentialsP1(){
        if(File.Exists(Application.dataPath + "/save.txt")){
            //Load the save file to an array
            string loadedData = File.ReadAllText(Application.dataPath + "/save.txt");
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
                    return;
                }
            }
            Debug.Log("Not registered/ Wrong login credentials");
        }
    }

    public void CheckCredentialsP2(){
        if(File.Exists(Application.dataPath + "/save.txt")){
            //Load the save file to an array
            string loadedData = File.ReadAllText(Application.dataPath + "/save.txt");
            List<RegisterData> myLoginDatas = JsonUtility.FromJson<RegisterDataHolder>(loadedData).registerDatas.ToList();
            //Check if the login username & password matches any of the registered data
            foreach(RegisterData registerData in myLoginDatas){
                string uname = registerData.myUsername;
                string pw = registerData.myPassword;
                if(uname == username.text && pw == password.text){
                    Debug.Log("Logged in succesfully");
                    PlayerPrefs.SetString("p2Name", uname);
                    playersReadyManager.SetP2Ready();
                    return;
                }
            }
            Debug.Log("Not registered/ Wrong login credentials");
        }
    }

}
