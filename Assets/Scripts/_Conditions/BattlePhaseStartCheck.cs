using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/BattlePhaseStartCheck")]
public class BattlePhaseStartCheck : Condition
{
    public override bool IsValid()
    {
        GameManager gm = GameManager.gmSingleton;
        PlayerHolder player = gm.currentPlayer;
        int count = gm.currentPlayer.cardsDown.Count;

        for (int i = 0; i < player.cardsDown.Count; i++)
        {
            if (!player.cardsDown[i].isUsable)
                count--;
        }

        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
