using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "GameElements/MyHandCard")]
public class HandCard : GameElementLogic
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
    }
}
