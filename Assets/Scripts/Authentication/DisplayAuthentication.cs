using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAuthentication : MonoBehaviour
{
    [SerializeField]private GameObject login, register, buttons, backBtn;
    
    //Show the login/register panel when u click on the login/register button
    public void DisplayLogin(){
        login.SetActive(true);
        buttons.SetActive(false);
        backBtn.SetActive(true);
    }

    public void DisplayRegister(){
        register.SetActive(true);
        buttons.SetActive(false);
        backBtn.SetActive(true);
    }

    public void GoBack(){
        buttons.SetActive(true);
        login.SetActive(false);
        register.SetActive(false);
        backBtn.SetActive(false);
    }
}
