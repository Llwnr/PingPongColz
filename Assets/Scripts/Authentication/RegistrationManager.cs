using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using System.IO;

public class RegistrationManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField username, password;
    [SerializeField] private PlayersReady playersReadyManager;
    protected string saveFileName = "/UserRegistrationData.txt";
    //Handles Registration
    public void StoreCredentials() {
        string uname = username.text;
        string pw = password.text;

        //Check if user given input for username and password is correct. 
        if (InputVerified(uname, pw) == false) return;

        //Make/Access the save file to update it
        RegisterDataHolder registerDataHolder;
        List<RegisterData> registerDataList;
        Debug.Log(Application.dataPath + saveFileName);
        if (File.Exists(Application.dataPath + saveFileName)) {
            string loadedData = File.ReadAllText(Application.dataPath + saveFileName);
            registerDataHolder = JsonUtility.FromJson<RegisterDataHolder>(loadedData);
            registerDataList = registerDataHolder.registerDatas.ToList();
        }
        else {
            registerDataHolder = new RegisterDataHolder();
            registerDataList = new List<RegisterData>();
        }
        //Write the data values and add it to the save file
        RegisterData registerData = new RegisterData {
            myUsername = uname,
            myPassword = pw
        };
        registerDataList.Add(registerData);
        //Convert the list into array and set it to register data holder's array
        registerDataHolder.registerDatas = registerDataList.ToArray();
        //Then serialize it
        string json = JsonUtility.ToJson(registerDataHolder);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath + saveFileName, json);
    }

    bool InputVerified(string username, string password) {
        //For usernames
        if (username.Length < 2) return false;

        //Check if username already exists
        RegisterDataHolder registerDataHolder;
        List<RegisterData> registerDataList;
        Debug.Log(Application.dataPath + saveFileName);
        if (File.Exists(Application.dataPath + saveFileName)) {
            string loadedData = File.ReadAllText(Application.dataPath + saveFileName);
            registerDataHolder = JsonUtility.FromJson<RegisterDataHolder>(loadedData);
            registerDataList = registerDataHolder.registerDatas.ToList();

            foreach(RegisterData registerData in registerDataList) {
                if (registerData.myUsername == username) {
                    transform.parent.GetComponent<LoginErrorAnim>().StartShake();
                    return false;
                }
            }
            Debug.Log("Same username exists");
        }

        //For passwords
        if (password.Length < 7) return false;

        //Finally if all the anomalities are passed, verification is done so return as true(verified)
        return true;
    }
}
