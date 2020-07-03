﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Turns/BattlePhase")]
public class BattlePhase : Phase
{
    public GameState playerBattleState;

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
        if (!isInit)
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
            Settings._gameManager.SetState(playerBattleState);
            Settings._gameManager.onPhaseChanged.Raise();
            isInit = true;
        }
    }
}
