﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName ="Actions/Player Actions/Set Cards To Attack")]
public class SetCardsToAttack : PlayerAction
{
    public override void Execute(PlayerHolder player)
    {
        foreach(CardInstance card in player.cardsDownMelee)
        {
            if (!card.isUsable)
            {
                card.cardViz.transform.localEulerAngles = Vector3.zero;
                card.isUsable = true;
            }
        }

        foreach (CardInstance card in player.cardsDownRanged)
        {
            if (!card.isUsable)
            {
                card.cardViz.transform.localEulerAngles = Vector3.zero;
                card.isUsable = true;
            }
        }
    }
}
