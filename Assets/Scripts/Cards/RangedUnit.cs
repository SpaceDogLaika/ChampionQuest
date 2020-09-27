using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Cards/RangedUnit")]
public class RangedUnit : CardType
{
    public override void OnSetType(CardViz viz)
    {
        base.OnSetType(viz);

        viz.statsHolder.SetActive(true);
    }
}
