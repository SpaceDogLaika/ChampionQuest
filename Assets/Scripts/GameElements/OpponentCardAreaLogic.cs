using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Areas/OpponentCardAreaLogic")]
public class OpponentCardAreaLogic : AreaLogic
{
    public CardVariable card;
    public CardVariable targetCard;

    public override void Execute()
    {
        if (!card.value)
            return;


        if (card.value.isUsable)
        {

        }

    }
}
