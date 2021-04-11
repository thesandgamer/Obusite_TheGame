using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Cursor : MonoBehaviour
{
    public Texture2D mouseCursor;
    public Texture2D mouseMoveCursor;
    public Texture2D mouseAttackCursor;
    public Texture2D mouseAutoCursor;

    Vector2 hotSpot = new Vector2(0, 0);
    CursorMode cursorMode = CursorMode.Auto;

    private void Start()
    {
        SetCursor();
    }

    public void SetCursor()
    {
        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
    }
    public void SetMoveCursor()
    {
        Cursor.SetCursor(mouseMoveCursor, hotSpot, cursorMode);
    }
    
    public void SetAttackCursor()
    {
        Cursor.SetCursor(mouseAttackCursor, hotSpot, cursorMode);
    }

    public void SetAutoCursor()
    {
        Cursor.SetCursor(mouseAutoCursor, hotSpot, cursorMode);
    }



}
