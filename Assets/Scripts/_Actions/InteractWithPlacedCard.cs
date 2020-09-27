using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Actions/Interact With Placed Card")]
public class InteractWithPlacedCard : Action
{
    public override void Execute(float d)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var results = Settings.GetUIObjects();

            foreach (RaycastResult result in results)
            {
                CardInstance instance = result.gameObject.GetComponentInParent<CardInstance>();
                PlayerHolder player = Settings._gameManager.currentPlayer;

                if (!player.cardsDownMelee.Contains(instance) || !player.cardsDownRanged.Contains(instance))
                    return;

                if (instance.CanAttack())
                {
                    player.attackingCards.Add(instance);
                    // you can attack
                }
            }
        }
    }
}
