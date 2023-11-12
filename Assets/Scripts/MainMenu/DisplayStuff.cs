using UnityEngine;

public class DisplayStuff : MonoBehaviour
{   
    public void HideGameobject(GameObject obj){
        obj.SetActive(false);
    }

    public void ShowGameobject(GameObject obj){
        //Hide the current section
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
        //Show the linked section
        obj.SetActive(true);
    }
}
