using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public List<int> cardIds;
    public CardManager CM;

    public CardYasir Draw()
    {
        if (cardIds.Count > 0)
        {
            CardYasir drawnCard = CM.GetCard(cardIds[cardIds.Count - 1]);
            cardIds.RemoveAt(cardIds.Count - 1);
            return drawnCard;
        }
        else
        {
            return null;
        }
    }
    
    public void Shuffle() {
        List<int> shuffledCard = new List<int>();
        while (cardIds.Count > 0)
        {
            int index = Random.Range(0, cardIds.Count);
            shuffledCard.Add(cardIds[index]);
            shuffledCard.RemoveAt(index);
        }
        cardIds = shuffledCard;
    }
}
