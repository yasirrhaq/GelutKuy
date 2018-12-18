using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusController : MonoBehaviour {

    public Hand player;
    public Deck deck;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI deckText;
    
    public void UpdateHealthUI()
    {
        healthText.text = "HP: " + player.health;
    }

    public void UpdateDeckUI()
    {
        if (!player.recycled)
        {
            deckText.text = "Deck: " + deck.cardIds.Count;
        }
        else
        {
            deckText.text = "Deck: " + deck.graveCardControllers.Count;
        }
    }
}
