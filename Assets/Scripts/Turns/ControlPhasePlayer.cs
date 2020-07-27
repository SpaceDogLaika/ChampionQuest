using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/Control Phase Player")]
public class ControlPhasePlayer : Phase
{
    public GameState playerControlState;

    public override bool IsComplete()
    {
        if (forceExit)
        {
            forceExit = false;
            return true;
        }

        return false;
    }

    public override void OnEndPhase()
    {
        if (isInit)
        {
            Settings._gameManager.SetState(null);
            isInit = false;
        }
    }

    public override void OnStartPhase()
    {
        if (!isInit)
        {
            Debug.Log(this.name + "starts");
            Settings._gameManager.SetState(playerControlState);
            Settings._gameManager.onPhaseChanged.Raise();
            isInit = true;
        }
    }
}
