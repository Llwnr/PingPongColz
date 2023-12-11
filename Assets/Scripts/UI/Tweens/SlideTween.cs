using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideTween : MonoBehaviour
{
    [SerializeField]private Vector2 startPos, endPos;
    [SerializeField] private float duration;
    //preserve original anchor
    private RectTransform rectTransform;

    [SerializeField] private bool autoAdjust;
    private Vector2 origLocalPos;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        origLocalPos = transform.localPosition;

        if (autoAdjust) {
            endPos.y = -rectTransform.sizeDelta.y * 0.5f + 480f;
        }
    }

    private void OnEnable() {
        transform.localPosition = startPos;
        transform.LeanMoveLocal(endPos, duration).setEaseOutExpo();
    }

    private void OnDisable() {
        transform.localPosition = origLocalPos;
    }
}
