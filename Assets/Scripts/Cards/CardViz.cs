using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardViz : MonoBehaviour
{
    public Card card;
    public CardVizProperties[] properties;
    public GameObject statsHolder;
    public GameObject resourceHolder;
    private Vector3 startPosition;

    public void Start()
    {
        startPosition = gameObject.transform.position;
    }

    public void CloseAll()
    {
        foreach (CardVizProperties property in properties)
        {
            if (property.img != null)
                property.img.gameObject.SetActive(false);
            if (property.text != null)
                property.text.gameObject.SetActive(false);
        }
    }

    public void LoadCard(Card card)
    {
        if (card == null)
            return;

        this.card = card;

        card.cardType.OnSetType(this);

        CloseAll();

        for (int i = 0; i < card.properties.Length; i++)
        {
            CardProperties cardProperties = card.properties[i];

            CardVizProperties cardVizProperties = GetProperty(cardProperties.element);

            if (cardVizProperties == null)
                continue;

            if (cardProperties.element is ElementInt)
            {
                cardVizProperties.text.text = cardProperties.integerValue.ToString();
                cardVizProperties.text.gameObject.SetActive(true);
            }
            else if (cardProperties.element is ElementText)
            {
                cardVizProperties.text.text = cardProperties.stringValue;
                cardVizProperties.text.gameObject.SetActive(true);
            }
            else if (cardProperties.element is ElementImage)
            {
                cardVizProperties.img.sprite = cardProperties.sprite;
                cardVizProperties.img.gameObject.SetActive(true);
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

    public void UpdateHealthUI(int newHP)
    {
        properties[8].text.text = newHP.ToString();
    }

    public void UpdateAttack(int newAttack)
    {
        properties[9].text.text = newAttack.ToString();

    }

    public void ResetToStartPosition()
    {
        gameObject.transform.position = startPosition;
    }
}
