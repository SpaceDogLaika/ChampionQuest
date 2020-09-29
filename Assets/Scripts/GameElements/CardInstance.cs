using UnityEngine;
using System.Collections;

public class CardInstance : MonoBehaviour, IClickable
{
    public CardViz cardViz;
    public GameElementLogic currentLogic;
    public bool isUsable;
    public bool isHighlighted = false;
    public int startAttack;
    public int currentAttack;
    public int startHp;
    public int currentHp;

    void Start()
    {
        cardViz = GetComponent<CardViz>();

        startAttack = cardViz.card.attack;
        startHp = cardViz.card.hp;

        currentAttack = startAttack;
        currentHp = startHp;
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

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
