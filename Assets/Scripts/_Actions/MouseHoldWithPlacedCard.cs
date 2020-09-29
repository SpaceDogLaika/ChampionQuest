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
        bool mouseIsDown = Input.GetMouseButton(0);
        IClickable clickable = null;


        if (!mouseIsDown)
        {
            var results = Settings.GetUIObjects();

            foreach (RaycastResult result in results)
            {
                // Check for enemy units to attack
                clickable = result.gameObject.GetComponentInParent<IClickable>();

            }

            currentCard.value.gameObject.SetActive(true);
            currentCard.value = null;

            Settings._gameManager.SetState(playerControlState);
            onPlayerControlState.Raise();
            return;
        }
    }
}
