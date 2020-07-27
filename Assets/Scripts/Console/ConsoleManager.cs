using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{
    public Transform consoleGrid;
    public GameObject prefab;
    private Text[] textObjects;
    private int index;

    public ConsoleHook hook;

    private void Awake()
    {
        hook.consoleManager = this;

        textObjects = new Text[7];
        for (int i = 0; i < textObjects.Length; i++)
        {
            GameObject gameObject = Instantiate(prefab) as GameObject;
            textObjects[i] = gameObject.GetComponent<Text>();
            gameObject.transform.SetParent(consoleGrid);
        }
    }

    public void RegisterEvent(string eventString, Color color)
    {
        index++;

        if (index > textObjects.Length - 1)
        {
            index = 0;
        }

        textObjects[index].color = color;
        textObjects[index].text = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + eventString;
        textObjects[index].gameObject.SetActive(true);
        textObjects[index].transform.SetAsLastSibling();
    }
}
