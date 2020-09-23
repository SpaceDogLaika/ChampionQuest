using UnityEngine;
using System.Collections;
using SO;

[CreateAssetMenu(menuName = "Holders/Card Holder")]
public class CardHolders : ScriptableObject
{
    public TransformVariable handGrid;
    public TransformVariable downGridRanged;
    public TransformVariable downGridMelee;
    public TransformVariable resourcesGrid;

    public void LoadPlayer(PlayerHolder player, PlayerStatsUI statsUI)
    {
        foreach (CardInstance c in player.cardsDownMelee)
        {
            Settings.SetParentForCard(c.cardViz.gameObject.transform, downGridMelee.value.transform);
        }

        foreach (CardInstance c in player.cardsDownRanged)
        {
            Settings.SetParentForCard(c.cardViz.gameObject.transform, downGridRanged.value.transform);
        }

        foreach (CardInstance c in player.handCards)
        {
            Settings.SetParentForCard(c.cardViz.gameObject.transform, handGrid.value.transform);
        }

        foreach (ResourceHolder c in player.resourcesList)
        {
            Settings.SetParentForCard(c.cardObject.gameObject.transform, resourcesGrid.value.transform);
        }

        player.playerStatsUI = statsUI;
        player.LoadPlayerOnStatsUI();
    }
}
