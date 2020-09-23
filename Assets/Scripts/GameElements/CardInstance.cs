using UnityEngine;
using System.Collections;

public class CardInstance : MonoBehaviour, IClickable
{
    public CardViz cardViz;
    public GameElementLogic currentLogic;
    public bool isUsable;
    public bool isHighlighted = false;

    void Start()
    {
        cardViz = GetComponent<CardViz>();
    }

    public bool CanAttack()
    {
        var result = true;

        if (!isUsable)
            result = false;

        if (cardViz.card.cardType.TypeAllowsForAttack(this))
        {
            result = true;
        }

        return result;
    }

    public void OnClick()
    {
        if (currentLogic == null)
            return;

        currentLogic.OnClick(this);
    }

    public void OnHighlight()
    {
        if (currentLogic == null)
            return;

        isHighlighted = true;

        currentLogic.OnHighlight(this);
    }

    public void OnHighlightOff()
    {
        if (currentLogic == null)
            return;

        isHighlighted = false;

        currentLogic.OnHighlightOff(this);
    }

    public void ChangeToPlacedCard()
    {
        var placedCard = transform.Find("PlacedCard");
        var fullCard = transform.Find("CardTemplate");
        fullCard.gameObject.SetActive(false);
        placedCard.gameObject.SetActive(true);
    }
}
