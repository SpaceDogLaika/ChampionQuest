using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSelected : MonoBehaviour
{
    public CardVariable currentCard;
    public CardViz cardViz;

    private Transform mTransform;

    public void LoadCard()
    {
        if (currentCard.value == null)
            return;

        currentCard.value.gameObject.SetActive(false);
        cardViz.LoadCard(currentCard.value.cardViz.card);
        cardViz.gameObject.SetActive(true);

    }

    public void CloseCard()
    {
        cardViz.gameObject.SetActive(false);
    }

    private void Start()
    {
        mTransform = this.transform;
        CloseCard();
    }

    void Update()
    {
        mTransform.position = Input.mousePosition;
    }
}
