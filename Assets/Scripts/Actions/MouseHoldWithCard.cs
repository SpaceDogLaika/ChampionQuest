using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Actions/MouseHoldWithCard")]
public class MouseHoldWithCard : Action
{
    public CardVariable currentCard;
    public GameState playerControlState;
    public SO.GameEvent onPlayerControlState;

    public override void Execute(float d)
    {
        bool mouseIsDown = Input.GetMouseButton(0);

        if (!mouseIsDown)
        {
            var results = Settings.GetUIObjects();

            foreach (RaycastResult result in results)
            {
                // Check for droppable areas
                Area area = result.gameObject.GetComponentInParent<Area>();

                if (area)
                {
                    area.OnDrop();
                    break;
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
