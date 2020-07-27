using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Turns/ResetCurrentPlayerResourceCards")]
public class ResetCurrentPlayerResourceCards : Phase
{
    public override bool IsComplete()
    {
        Settings._gameManager.currentPlayer.MakeAllResourceCardsUsable();

        return true;
    }

    public override void OnEndPhase()
    {
    }

    public override void OnStartPhase()
    {
    }
}
