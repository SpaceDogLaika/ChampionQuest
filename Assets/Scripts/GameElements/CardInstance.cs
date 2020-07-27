using UnityEngine;
using System.Collections;

public class CardInstance : MonoBehaviour, IClickable
{
    public CardViz cardViz;
    public GameElementLogic currentLogic;
    public bool isUsable;

    void Start()
    {
        cardViz = GetComponent<CardViz>();
    }

    public void OnClick()
    {
        if (currentLogic == null)
            return;

        currentLogic.OnClick(this);
    }

    public void OnHighlight()
    {
        if (currentLogic == null)
            return;

        currentLogic.OnHighlight(this);
    }
}
