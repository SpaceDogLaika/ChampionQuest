using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Areas/MyCardsDownWhenHoldingCard")]
public class MyCardsDownAreaLogic : AreaLogic
{
    public CardVariable card;
    public CardType creatureType;
    public CardType resourceType;
    public SO.TransformVariable areaGrid;
    public SO.TransformVariable resourceGrid;
    public GameElementLogic cardDownLogic;

    public override void Execute()
    {
        if (!card.value)
            return;

        Card thisCard = card.value.cardViz.card;

        if (thisCard.cardType == creatureType)
        {
            var canUse = Settings._gameManager.currentPlayer.CanUseCard(thisCard);

            if (canUse)
            {
                Settings.DropCreatureCard(card.value.transform, areaGrid.value.transform, card.value);
                card.value.currentLogic = cardDownLogic;
            }
            else
            {
                Settings.RegisterEvent("Not enough resources to drop card", Color.white);
            }

            card.value.gameObject.SetActive(true);

            // Place card down
        } else if(thisCard.cardType == resourceType)
        {
            var canUse = Settings._gameManager.currentPlayer.CanUseCard(thisCard);

            if (canUse)
            {
                Settings.SetParentForCard(card.value.transform, resourceGrid.value.transform);
                card.value.currentLogic = cardDownLogic;
                Settings._gameManager.currentPlayer.AddResourceCard(card.value.gameObject);
            }
            else
            {
                Settings.RegisterEvent("Can't drop any more resource cards", Color.white);
            }

            card.value.gameObject.SetActive(true);

        }

        Settings.RegisterEvent("Could not place card");

    }
}
