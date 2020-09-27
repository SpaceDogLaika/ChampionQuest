using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TurnStartCheck")]
public class TurnStartCheck : Condition
{
    public override bool IsValid()
    {
        GameManager gm = GameManager.gmSingleton;
        PlayerHolder player = gm.currentPlayer;
        int count = gm.currentPlayer.cardsDownMelee.Count;

        for (int i = 0; i < player.cardsDownMelee.Count; i++)
        {
            if (!player.cardsDownMelee[i].isUsable)
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
