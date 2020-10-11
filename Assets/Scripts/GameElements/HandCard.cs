using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "GameElements/MyHandCard")]
public class HandCard : GameElementLogic
{
    public SO.GameEvent onCurrentCardSelected;
    public CardVariable currentCard;
    public GameState holdingCard;
    public float speed = 1.0f;

    public override void OnClick(CardInstance cardInstance)
    {
        currentCard.Set(cardInstance);
        Settings._gameManager.SetState(holdingCard);
        onCurrentCardSelected.Raise();
    }

    public override void OnHighlight(CardInstance cardInstance)
    {
        float step = speed * Time.deltaTime; // calculate distance to move

        currentCard.Set(cardInstance);

        /// Need to figure out a way to set the currently highlighted card to the top of pile
        /// currentCard.value.gameObject.transform.SetSiblingIndex(0);

        /// Need to figure out a way to 
        //var currentPosition = currentCard.value.cardViz.gameObject.transform.localPosition;
        //var desiredPostion = currentCard.value.cardViz.gameObject.transform.localPosition.y + 50;
        //currentCard.value.cardViz.gameObject.transform.localPosition = Vector3.MoveTowards(
        //    currentPosition, 
        //    new Vector2(currentPosition.x, desiredPostion), 
        //    step);
    }

    public override void OnHighlightOff(CardInstance cardInstance)
    {
        //float step = speed * Time.deltaTime; // calculate distance to move

        //currentCard.value.cardViz.gameObject.transform.localPosition = Vector3.MoveTowards(
        //    currentCard.value.cardViz.gameObject.transform.localPosition,
        //    new Vector3(currentCard.value.cardViz.gameObject.transform.localPosition.x, currentCard.value.cardViz.gameObject.transform.localPosition.x - 50,
        //    currentCard.value.cardViz.gameObject.transform.localPosition.z),
        //    step);
    }
}
