using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour {

    public Deck deck;
    public Hand hand;
    public List<CardController> usedCardControllers;
    public StatusController status;

    public void RecycleCards()
    {
        foreach (CardController usedCard in usedCardControllers)
        {
            usedCard.transform.SetParent(deck.transform);
            usedCard.moving = true;
            usedCard.enabled = true;
            usedCard.FlipCard(false);

            deck.graveCardControllers.Add(usedCard);
        }

        usedCardControllers.RemoveRange(0, usedCardControllers.Count);

        deck.ShuffleController();
        hand.recycled = true;
        status.UpdateDeckUI();
    }
}