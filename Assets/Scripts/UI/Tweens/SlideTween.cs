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
    private Vector2 origAnchorMin, origAnchorMax;

    [SerializeField] private bool autoAdjust;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        origAnchorMin = rectTransform.anchorMin;
        origAnchorMax = rectTransform.anchorMax;

        if (autoAdjust) {
            endPos.y = -GetComponent<RectTransform>().sizeDelta.y * 0.5f + 480f;
        }
    }

    private void OnEnable() {
        transform.localPosition = startPos;
        transform.LeanMoveLocal(endPos, duration).setEaseOutExpo();

        StartCoroutine(ResetAnchor());
    }

    IEnumerator ResetAnchor() {
        yield return new WaitForSeconds(duration);

        rectTransform.anchorMax = origAnchorMax;
        rectTransform.anchorMin = origAnchorMin;

        transform.localPosition = endPos;
    }
}
