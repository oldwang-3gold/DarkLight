using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private static CursorManager instance;

    public static CursorManager GetInstance()
    {
        return instance;
    }

    public Texture2D cursorNormal;
    public Texture2D cursorNpcTalk;
    public Texture2D cursorAttack;
    public Texture2D cursorLockTarget;
    public Texture2D cursorPick;

    private Vector2 hotspot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            instance = null;
        }
        
    }

    public void SetCursorNormal()
    {
        Cursor.SetCursor(cursorNormal,hotspot,cursorMode);
    }

    public void SetCursorNpcTalk()
    {
        Cursor.SetCursor(cursorNpcTalk,hotspot,cursorMode);
    }
}
