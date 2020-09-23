using ChampionQuest.Enumerations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardType : ScriptableObject
{
    public string typeName;
    public bool canAttack;
    public CardTypeEnum cardTypeEnum;

    // public TypeLogic logic;

    public virtual void OnSetType(CardViz viz)
    {
        Element element = Settings.GetResourcesManager().typeElement;
        CardVizProperties type = viz.GetProperty(element);
        type.text.text = typeName;
    }

    public bool TypeAllowsForAttack(CardInstance instance)
    {
        /// example for special cards e.g "Initiative" special cards
        /// if (
        /// 

        if (instance.cardViz.card.cardPassiveType.Equals(CardPassiveType.Initiative))
            canAttack = true;

        if (canAttack)
            return true;
        else
            return false;
    }
}
