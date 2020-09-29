using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighight : MonoBehaviour
{
    public GameObject hand;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CardInstance card in hand.GetComponentsInChildren<CardInstance>())
        {
            if (card.isHighlighted)
            {
                card.isHighlighted = false;
                float step = speed * Time.deltaTime; // calculate distance to move

                card.cardViz.gameObject.transform.localPosition = Vector3.MoveTowards(
                    card.cardViz.gameObject.transform.localPosition,
                    new Vector3(card.cardViz.gameObject.transform.localPosition.x, card.cardViz.gameObject.transform.localPosition.x - 50,
                    card.cardViz.gameObject.transform.localPosition.z),
                    step);
            }
        }
    }
}
