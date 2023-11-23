using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnHover : MonoBehaviour
{
    [SerializeField]private Texture2D hoverCursor;
    
    public void OnHover() {
        Cursor.SetCursor(hoverCursor, new Vector2(5.33f, 0.33f), CursorMode.Auto);
    }

    public void OnExit() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnDisable() {
        OnExit();
    }
}
