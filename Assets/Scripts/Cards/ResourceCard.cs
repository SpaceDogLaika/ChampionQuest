using UnityEngine;

namespace Assets.Scripts.Cards
{
    [CreateAssetMenu(menuName = "Cards/Resource")]
    public class ResourceCard : CardType
    {
        public override void OnSetType(CardViz viz)
        {
            base.OnSetType(viz);

            viz.statsHolder.SetActive(false);
            viz.resourceHolder.SetActive(false);
        }
    }
}
