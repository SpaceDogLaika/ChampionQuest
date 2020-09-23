using ChampionQuest.Enumerations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public CardType cardType;
    public int cardCost;
    public CardProperties[] properties;
    public CardClass cardClass;
    public CardPassiveType[] cardPassiveType;

}
