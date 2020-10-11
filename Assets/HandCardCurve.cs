using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardCurve : MonoBehaviour
{
    private CardInstance[] cardsInHand;
    public GameObject pivotPoint;
    private Vector3 pivotPointPosition;
    // Start is called before the first frame update

    void Start()
    {
        pivotPointPosition = pivotPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cardsInHand = gameObject.GetComponentsInChildren<CardInstance>();

        if (cardsInHand.Length <= 1)
            return;

        for (int i = 0; i < cardsInHand.Length; i++)
        {
            if(cardsInHand.Length == 2)
            {
                cardsInHand[0].cardViz.gameObject.transform.localEulerAngles = new Vector3(0, 0, 10);
                cardsInHand[1].cardViz.gameObject.transform.localEulerAngles = new Vector3(0, 0, -10);
            }
            else if (cardsInHand.Length > 2 && cardsInHand.Length < 5)
            {

            } else
            {

            }

        }
    }
}
