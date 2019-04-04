using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public void OnMouseEnter()
    {
        CursorManager.GetInstance().SetCursorNpcTalk();
    }

    public void OnMouseExit()
    {
        CursorManager.GetInstance().SetCursorNormal();
    }
}
