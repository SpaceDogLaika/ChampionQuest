using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "GameState")]
public class GameState : ScriptableObject
{
    public Action[] actions;

    public void Tick(float d)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(d);
        }
    }
}
