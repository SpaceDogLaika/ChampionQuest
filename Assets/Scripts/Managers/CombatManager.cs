using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager cmSingleton;

    private void Awake()
    {
        cmSingleton = this;
    }

    public void ResolveBattle(CardVariable currentCard, CardInstance target)
    {
        var currentCardAttack = currentCard.value.currentAttack;
        var currentCardHp = currentCard.value.currentHp;

        var targetCardAttack = target.currentAttack;
        var targetCardHp = target.currentHp;

        // damage self
        currentCardHp -= targetCardAttack;
        // damage target
        targetCardHp -= currentCardAttack;
        // resolve
        if (currentCardHp < 1)
        {
            currentCard.value.DestroySelf();
        } else
        {
            currentCard.value.currentHp = currentCardHp;
        }

        if (targetCardHp < 1)
        {
            target.DestroySelf();
        } else
        {
            target.currentHp = targetCardHp;
        }
    }
}
