using Assets.Scripts.Cards;
using SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Holders/PlayerHolder")]
public class PlayerHolder : ScriptableObject
{
    public string username;
    public string[] startingCards;
    public Color playerColor;

    public GameElementLogic handLogic;
    public GameElementLogic downLogic;

    public bool isHumanPlayer;

    [System.NonSerialized]
    public CardHolders currentHolder;

    public int resourcesPerTurn = 1;

    [System.NonSerialized]
    public int resourcesDroppedThisTurn;

    [System.NonSerialized]
    public List<CardInstance> handCards = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsDown = new List<CardInstance>();

    [System.NonSerialized]
    public List<ResourceHolder> resourcesList = new List<ResourceHolder>();

    public int resourcesCount
    {
        get { return currentHolder.resourcesGrid.value.GetComponentsInChildren<CardViz>().Length; }
    }

    public void AddResourceCard(GameObject cardObject)
    {
        ResourceHolder resourceHolder = new ResourceHolder
        {
            cardObject = cardObject
        };

        resourcesList.Add(resourceHolder);

        Settings.RegisterEvent(username + " dropped a resource card", Color.white);
    }

    public int NonUsedCards()
    {
        int result = 0;

        for (int i = 0; i < resourcesList.Count; i++)
        {
            if (!resourcesList[i].isUsed)
            {
                result++;
            }
        }

        return result;
    }

    public bool CanUseCard(Card card)
    {
        var result = false;

        if (card.cardType is CreatureCard || card.cardType is SpellCard)
        {
            var currentResources = NonUsedCards();

            if (card.cardCost <= currentResources)
                result = true;

        }
        else
        {
            if (card.cardType is ResourceCard)
            {
                if(resourcesPerTurn - resourcesDroppedThisTurn > 0)
                {
                    result = true;
                    resourcesDroppedThisTurn++;
                }
            }
        }

        return result;
    }

    public void DropCard(CardInstance cardInstance)
    {
        if (handCards.Contains(cardInstance))
            handCards.Remove(cardInstance);

        cardsDown.Add(cardInstance);

        Settings.RegisterEvent(username + " used " + cardInstance.cardViz.card.name + " for " + cardInstance.cardViz.card.cardCost, Color.white);
    }

    public List<ResourceHolder> GetUnusedResources()
    {
        List<ResourceHolder> result = new List<ResourceHolder>();

        for (int i = 0; i < resourcesList.Count; i++)
        {
            if (!resourcesList[i].isUsed)
            {
                result.Add(resourcesList[i]);
            }
        }

        return result;
    }

    public void MakeAllResourceCardsUsable()
    {
        for (int i = 0; i < resourcesList.Count; i++)
        {
            resourcesList[i].isUsed = false;
            resourcesList[i].cardObject.transform.localEulerAngles = Vector3.zero;
        }

        resourcesDroppedThisTurn = 0;
    }

    public void UseResourceCards(int amount)
    {
        Vector3 euler = new Vector3(0, 0, 90);

        List<ResourceHolder> list = GetUnusedResources();

        for (int i = 0; i < amount; i++)
        {
            list[i].isUsed = true;
            list[i].cardObject.transform.localEulerAngles = euler;
        }
    }
}
