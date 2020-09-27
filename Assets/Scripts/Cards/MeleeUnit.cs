using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Cards/MeleeUnit")]
public class MeleeUnit : CardType
{
    public override void OnSetType(CardViz viz)
    {
        base.OnSetType(viz);

        viz.statsHolder.SetActive(true);
    }
}
