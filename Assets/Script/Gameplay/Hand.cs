using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public Deck deck;

    public List<CardYasir> cards;
    public List<GameObject> cardObjects;

    public Transform[] cardPos;

    public int index;
    public int cardCount;

    public void Draw()
    {
        if (deck.cardIds.Count > 0)
        {
            cards.Add(deck.Draw());
            GameMaster.gm.CreateCard(cards[index], deck.transform, cardPos[index], cardObjects);
            index++;
        }
    }

    public void Draw3()
    {
        for (int i = 0; i < 3; i++)
        {
            Draw();
        }
    }
}