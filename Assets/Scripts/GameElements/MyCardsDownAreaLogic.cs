using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Areas/MyCardsDownWhenHoldingCard")]
public class MyCardsDownAreaLogic : AreaLogic
{
    public CardVariable card;
    public CardType creatureType;
    public SO.TransformVariable areaGrid;
    public GameElementLogic cardDownLogic;

    public override void Execute()
    {
        if (!card.value)
            return;

        if(card.value.cardViz.card.cardType == creatureType)
        {
            Debug.Log("Place card down");

            Settings.SetParentForCard(card.value.transform, areaGrid.value.transform);
            card.value.gameObject.SetActive(true);
            card.value.currentLogic = cardDownLogic;
            // Place card down
        }
    }
}
