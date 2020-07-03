using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardViz : MonoBehaviour
{
    public Card card;
    public CardVizProperties[] properties;
    public GameObject statsHolder;
    public GameObject resourceHolder;

    public void LoadCard(Card card)
    {
        if (card == null)
            return;

        this.card = card;

        card.cardType.OnSetType(this);

        for (int i = 0; i < card.properties.Length; i++)
        {
            CardProperties cardProperties = card.properties[i];

            CardVizProperties cardVizProperties = GetProperty(cardProperties.element);

            if (cardVizProperties == null)
                continue;

            if (cardProperties.element is ElementInt)
            {
                cardVizProperties.text.text = cardProperties.integerValue.ToString();
            }
            else if (cardProperties.element is ElementText)
            {
                cardVizProperties.text.text = cardProperties.stringValue;
            }
            else if (cardProperties.element is ElementImage)
            {
                cardVizProperties.img.sprite = cardProperties.sprite;
            }
        }

    }

    public CardVizProperties GetProperty(Element e)
    {
        CardVizProperties result = null;

        for (int i = 0; i < properties.Length; i++)
        {
            if (properties[i].element == e)
            {
                result = properties[i];
                break;
            }
        }
        return result;
    }
}
