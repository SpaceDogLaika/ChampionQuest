using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "GameElements/MyCardsDown")]
public class MyCardsDown : GameElementLogic
{
    public override void OnClick(CardInstance cardInstance)
    {
        Debug.Log("This card is on my side of the board");
    }

    public override void OnHighlight(CardInstance cardInstance)
    {
    }
}
