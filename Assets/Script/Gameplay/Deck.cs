using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public List<int> cardIds;
    public CardManager CM;
    public StatusController playerStatus;

    public List<CardController> graveCardControllers;

    public CardYasir Draw()
    {
        if (cardIds.Count > 0)
        {
            CardYasir drawnCard = CM.GetCard(cardIds[cardIds.Count - 1]);
            cardIds.RemoveAt(cardIds.Count - 1);
            playerStatus.UpdateDeckUI();
            return drawnCard;
        }
        else
        {
            return null;
        }

    }

    public CardController DrawController()
    {
        if (graveCardControllers.Count > 0)
        {
            CardController newCardController = graveCardControllers[graveCardControllers.Count - 1];
            graveCardControllers.RemoveAt(graveCardControllers.Count - 1);
            playerStatus.UpdateDeckUI();
            return newCardController;
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
            cardIds.RemoveAt(index);
        }
        cardIds = shuffledCard;
    }

    public void ShuffleController()
    {
        List<CardController> shuffledCard = new List<CardController>();
        while (graveCardControllers.Count > 0)
        {
            int index = Random.Range(0, graveCardControllers.Count);
            shuffledCard.Add(graveCardControllers[index]);
            graveCardControllers.RemoveAt(index);
        }
        graveCardControllers = shuffledCard;
    }
}
