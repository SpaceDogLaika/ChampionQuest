using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "GameElements/MyCardsDown")]
public class MyCardsDown : GameElementLogic
{
    public SO.GameEvent onCurrentCardSelected;
    public CardVariable currentCard;
    public GameState holdingCard;

    public override void OnClick(CardInstance cardInstance)
    {
        currentCard.Set(cardInstance);
        Settings._gameManager.SetState(holdingCard);
        onCurrentCardSelected.Raise();
    }

    public override void OnHighlight(CardInstance cardInstance)
    {
        // Need to show full version of card here
    }

    public override void OnHighlightOff(CardInstance cardInstance)
    {
    }
}
