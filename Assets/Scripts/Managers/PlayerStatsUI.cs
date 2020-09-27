using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public PlayerHolder player;
    public Image playerPortrait;
    public Text playerHp;
    public Text username;
    public Text playerResources;

    public void UpdateAll()
    {
        UpdateUsername();
        UpdateHealth();
        UpdateResources();
    }

    public void UpdateUsername()
    {
        username.text = player.username;
        playerPortrait.sprite = player.playerPortrait;
    }

    public void UpdateHealth()
    {
        playerHp.text = player.hp.ToString();
    }

    public void UpdateResources()
    {
        playerResources.text = player.currentResources.ToString();
    }
}
