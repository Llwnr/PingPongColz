using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    [SerializeField]private GameObject dropdown;

    public void Toggle(){
        //dropdown.SetActive(!dropdown.activeSelf);
        dropdown.GetComponent<TMP_Dropdown>().Show();
        foreach(TMP_Dropdown.OptionData optionData in dropdown.GetComponent<TMP_Dropdown>().options){
            Debug.Log(optionData.text);
        }
    }
}
