using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public static class Settings
{
    public static ResourcesManager _resourcesManager;
    public static GameManager _gameManager;
    private static ConsoleHook _consoleManager;

    public static void RegisterEvent(string eventString, Color color = default(Color))
    {
        if (_consoleManager == null)
        {
            _consoleManager = Resources.Load("ConsoleHook") as ConsoleHook;
        }

        _consoleManager.RegisterEvent(eventString, color);
    }

    public static ResourcesManager GetResourcesManager()
    {
        if (_resourcesManager == null)
        {
            _resourcesManager = Resources.Load("ResourcesManager") as ResourcesManager;
            _resourcesManager.Init();
        }

        return _resourcesManager;
    }

    public static List<RaycastResult> GetUIObjects()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        return results;
    }

    public static void DropCreatureCard(Transform current, Transform parent, CardInstance cardInstance)
    {
        cardInstance.isUsable = false;

        // Execute any special card abilities on drop here

        SetParentForCard(current, parent);

        if(cardInstance.isUsable == false)
        {
            cardInstance.ChangeToPlacedCard();
        }

        _gameManager.currentPlayer.DropCard(cardInstance);
    }

    public static void SetParentForCard(Transform current, Transform parent)
    {
        current.SetParent(parent);
        current.localPosition = Vector3.zero;
        current.localEulerAngles = Vector3.zero;
        current.localScale = Vector3.one;
    }
}
