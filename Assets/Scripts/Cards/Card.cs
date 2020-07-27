﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public CardType cardType;
    public int cardCost;
    public CardProperties[] properties;
}
