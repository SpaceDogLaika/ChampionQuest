using UnityEngine;
using System.Collections;
using ChampionQuest.Enumerations;

[CreateAssetMenu(menuName = "Cards/Item")]
public class ItemCard : CardType
{
    public ItemCardType itemCardType;

    public override void OnSetType(CardViz viz)
    {
        base.OnSetType(viz);

        viz.statsHolder.SetActive(false);
    }
}
