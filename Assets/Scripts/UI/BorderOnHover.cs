using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderOnHover : MonoBehaviour
{
    [SerializeField] private GameObject border;
    [SerializeField] private Color finalCol;
    private Color origColor;
    [SerializeField] private float transitionDuration;

    private Image borderImg;

    private void Start() {
        borderImg = border.GetComponent<Image>();
        origColor = borderImg.color;
    }

    //Set the border inside the button
    public void SetBorder(GameObject button) {
        LeanTween.cancelAll();

        border.SetActive(true);
        border.GetComponent<Image>().color = origColor;
        border.transform.SetParent(button.transform, false);
        border.GetComponent<RectTransform>().anchorMin = Vector3.zero;
        border.GetComponent<RectTransform>().anchorMax = Vector3.one;

        LeanTween.value(border, SetColorCallback, origColor, finalCol, transitionDuration);
    }

    //Remove border when not hovering
    public void RemoveBorder() {
        border.transform.SetParent(transform, false);
        border.SetActive(false);
    }

    void SetColorCallback(Color c) {
        borderImg.color = c;
    }
}
