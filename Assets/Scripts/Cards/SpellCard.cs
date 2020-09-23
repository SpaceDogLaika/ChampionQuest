using UnityEngine;
using System.Collections;
using ChampionQuest.Enumerations;

[CreateAssetMenu(menuName = "Cards/Spell")]
public class SpellCard : CardType
{
    public MagicCardType magicCardType;

    public override void OnSetType(CardViz viz)
    {
        base.OnSetType(viz);

        viz.statsHolder.SetActive(false);
    }
}
