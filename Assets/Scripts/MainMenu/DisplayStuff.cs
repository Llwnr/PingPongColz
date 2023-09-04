using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStuff : MonoBehaviour
{   
    public void HideGameobject(GameObject obj){
        obj.SetActive(false);
    }

    public void ShowGameobject(GameObject obj){
        obj.SetActive(true);
        //Hide the button option
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }
}
