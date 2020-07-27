using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName ="Actions/Player Actions/Enable placed cards")]
public class ResetFlatfootedCards : PlayerAction
{
    public override void Execute(PlayerHolder player)
    {
        foreach(CardInstance card in player.cardsDown)
        {
            if (!card.isUsable)
            {
                card.cardViz.transform.localEulerAngles = Vector3.zero;
                card.isUsable = true;
            }
        }
    }
}
