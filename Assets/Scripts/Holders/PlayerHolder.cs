using SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Holders/PlayerHolder")]
public class PlayerHolder : ScriptableObject
{
    public string username;
    public string[] startingCards;
    public TransformVariable handGrid;
    public TransformVariable downGrid;

    public GameElementLogic handLogic;
    public GameElementLogic downLogic;

    [System.NonSerialized]
    public List<CardInstance> handCards = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsDown = new List<CardInstance>();

}
