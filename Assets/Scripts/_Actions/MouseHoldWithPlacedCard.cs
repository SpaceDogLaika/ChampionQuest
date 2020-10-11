using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Actions/MouseHoldWithPlacedCard")]
public class MouseHoldWithPlacedCard : Action
{
    public CardVariable currentCard;
    public CardVariable targetCard;
    public GameState playerControlState;
    public SO.GameEvent onPlayerControlState;

    public override void Execute(float d)
    {
        CombatManager combatManager = CombatManager.cmSingleton;

        bool mouseIsDown = Input.GetMouseButton(0);
        CardInstance target = null;


        if (!mouseIsDown)
        {
            var results = Settings.GetUIObjects();

            foreach (RaycastResult result in results)
            {
                // Check for enemy units to attack
                target = result.gameObject.GetComponentInParent<CardInstance>();

                if (target != null)
                {
                    combatManager.ResolveBattle(currentCard, target);
                    currentCard.value.hasAttacked = true;
                }
            }

            currentCard.value.gameObject.SetActive(true);
            currentCard.value = null;

            Settings._gameManager.SetState(playerControlState);
            onPlayerControlState.Raise();
            return;
        }
    }
}
