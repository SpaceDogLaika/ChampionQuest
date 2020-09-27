using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Actions/Player Actions/Set Resources")]
public class SetResources : PlayerAction
{
    public override void Execute(PlayerHolder player)
    {
        if (player.currentMaxResources < 10)
        {
            player.currentMaxResources++;
            player.currentResources = player.currentMaxResources;
            player.LoadPlayerOnStatsUI();
        }
    }
}
