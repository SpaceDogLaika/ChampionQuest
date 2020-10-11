using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager cmSingleton;

    private void Awake()
    {
        cmSingleton = this;
    }

    public void ResolveBattle(CardVariable currentCard, CardInstance targetCard)
    {
        var currentCardAttack = currentCard.value.currentAttack;
        var currentCardHp = currentCard.value.currentHp;

        var targetCardAttack = targetCard.currentAttack;
        var targetCardHp = targetCard.currentHp;

        // damage self
        currentCardHp -= targetCardAttack;
        // damage target
        targetCardHp -= currentCardAttack;

        //update UI
        currentCard.value.cardViz.UpdateHealthUI(currentCardHp);
        targetCard.cardViz.UpdateHealthUI(targetCardHp);

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
            targetCard.DestroySelf();
        } else
        {
            targetCard.currentHp = targetCardHp;
        }
    }
}
