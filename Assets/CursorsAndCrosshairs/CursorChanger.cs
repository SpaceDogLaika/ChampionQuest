using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour {

    public Texture2D cursor;

	public void Start()
    {
        Vector2 hotSpot = new Vector2(800 / 2f, 800 / 2f);
        Cursor.SetCursor(cursor, hotSpot, CursorMode.Auto);
    }
}
