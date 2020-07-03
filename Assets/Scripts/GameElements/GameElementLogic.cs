using UnityEngine;
using System.Collections;

public abstract class GameElementLogic : ScriptableObject
{
    public abstract void OnClick(CardInstance cardInstance);
    public abstract void OnHighlight(CardInstance cardInstance);
}
