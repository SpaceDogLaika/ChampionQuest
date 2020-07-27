using UnityEngine;
using System.Collections;
using SO;

[CreateAssetMenu(menuName = "Holders/Card Holder")]
public class CardHolders : ScriptableObject
{
    public TransformVariable handGrid;
    public TransformVariable downGrid;
    public TransformVariable resourcesGrid;

    public void LoadPlayer(PlayerHolder holder)
    {
        foreach (CardInstance c in holder.cardsDown)
        {
            Settings.SetParentForCard(c.cardViz.gameObject.transform, downGrid.value.transform);
        }

        foreach (CardInstance c in holder.handCards)
        {
            Settings.SetParentForCard(c.cardViz.gameObject.transform, handGrid.value.transform);
        }

        foreach (ResourceHolder c in holder.resourcesList)
        {
            Settings.SetParentForCard(c.cardObject.gameObject.transform, resourcesGrid.value.transform);
        }
    }
}
