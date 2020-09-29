using Assets.Scripts.Cards;
using ChampionQuest.Enumerations;
using SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Holders/PlayerHolder")]
public class PlayerHolder : ScriptableObject
{
    public string username;
    public Sprite playerPortrait;
    public string[] startingCards;
    public Color playerColor;
    public int hp = 30;
    public PlayerStatsUI playerStatsUI;
    public int currentMaxResources;
    public int currentResources;
    public int turnCount;
    public bool isFirstTurn = true;

    public GameElementLogic handLogic;
    public GameElementLogic downLogic;

    public bool isHumanPlayer;

    [System.NonSerialized]
    public CardHolders currentHolder;

    [System.NonSerialized]
    public List<CardInstance> handCards = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsDownRanged = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsDownMelee = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsDownField = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> attackingCards = new List<CardInstance>();
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

    public bool CanUseCard(Card card)
    {
        var result = false;

        if (card.cardType is MeleeUnit || card.cardType is RangedUnit || card.cardType is SpellCard)
        {
            if (card.cardCost <= currentResources)
            {
                result = true;
                currentResources -= card.cardCost;
                playerStatsUI.UpdateResources();
            }
        }
        else
        {
            if (card.cardType is ResourceCard)
            {
                if (card.cardCost <= currentResources)
                {
                    result = true;
                    currentResources -= card.cardCost;
                    playerStatsUI.UpdateResources();
                }
            }
        }
        
        return result;
    }

    public void DropCard(CardInstance cardInstance)
    {
        if (handCards.Contains(cardInstance))
            handCards.Remove(cardInstance);

        if(cardInstance.cardViz.card.cardType.cardTypeEnum.Equals(CardTypeEnum.Melee))
            cardsDownMelee.Add(cardInstance);

        if (cardInstance.cardViz.card.cardType.cardTypeEnum.Equals(CardTypeEnum.Ranged))
            cardsDownRanged.Add(cardInstance);

        Settings.RegisterEvent(username + " used " + cardInstance.cardViz.card.name + " for " + cardInstance.cardViz.card.cardCost, Color.white);
    }

    public void LoadPlayerOnStatsUI()
    {
        if (playerStatsUI != null)
        {
            playerStatsUI.player = this;
            playerStatsUI.UpdateAll();
        }
    }

    public void DealDamage(int value)
    {
        hp -= value;
        if(playerStatsUI != null)
            playerStatsUI.UpdateHealth();
    }
}
