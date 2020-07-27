using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(menuName = "Console/Hook")]
public class ConsoleHook : ScriptableObject
{
    [System.NonSerialized]
    public ConsoleManager consoleManager;

    public void RegisterEvent(string eventString, Color color)
    {
        consoleManager.RegisterEvent(eventString, color);
    }
}
