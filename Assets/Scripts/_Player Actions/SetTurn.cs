using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Actions/Player Actions/Set Turn Count")]
public class SetTurn : PlayerAction
{
    public override void Execute(PlayerHolder player)
    {
        player.turnCount++;
    }
}
