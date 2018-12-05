using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public Deck deck;

    public List<CardYasir> cards;
    public List<CardController> cardControllers;

    public int index;
    public int cardCount;
    public int health;
    public int selectedIndex = 0;

    public GameObject cardSelector;

    public Animator selectorAnimator;

    public Transform battlePos;

    public CardController battleCard;

    public Transform graveyardPos;

    public void Draw(bool player)
    {
        if (deck.cardIds.Count > 0)
        {
            cards.Add(deck.Draw());
            GameMaster.gm.CreateCard(cards[index], deck.transform, this.transform, cardControllers);
            index++;
        }
            cardControllers[cardControllers.Count - 1].FlipCard(player);
    }

    public void NextCard()
    {
        if (selectedIndex == cardControllers.Count - 1)
        {
            selectedIndex = 0;
            ChangeSelectorPosition(selectedIndex);
        }
        else
        {
            selectedIndex++;
            ChangeSelectorPosition(selectedIndex);
        }
    }

    public void PrevCard()
    {
        if (selectedIndex == 0)
        {
            selectedIndex = cardControllers.Count - 1;
            ChangeSelectorPosition(selectedIndex);
        }
        else
        {
            selectedIndex--;
            ChangeSelectorPosition(selectedIndex);
        }
    }

    public void MoveToBattlePos()
    {
        cardControllers[selectedIndex].transform.SetParent(battlePos);
        cardControllers[selectedIndex].targetPos = Vector3.zero;
        cardControllers[selectedIndex].moving = true;
        cardControllers[selectedIndex].enabled = true;
        cardControllers[selectedIndex].FlipCard(false);
        battleCard = cardControllers[selectedIndex];
        cardControllers.RemoveAt(selectedIndex);
        selectedIndex = 0;
    }

    public void Rearrange()
    {
        if (cardControllers.Count > 0)
        {
            for (int i = 0; i < cardControllers.Count; i++)
            {
                cardControllers[i].targetPos = new Vector3(i * 1.5f, 0, 0); ;
                cardControllers[i].moving = true;
                cardControllers[i].enabled = true;
            }
        }
    }

    public void ChangeSelectorPosition(int cardIndex)
    {
        cardSelector.transform.localPosition = new Vector2(cardControllers[cardIndex].transform.localPosition.x, 2);
    }

    public void ToggleSelector(bool show)
    {
        if (show)
        {
            selectorAnimator.SetBool("Show", true);
            selectorAnimator.SetBool("Hide", false);
        }
        else
        {
            selectorAnimator.SetBool("Show", false);
            selectorAnimator.SetBool("Hide", true);
        }
    }

    public void Draw3(bool player)
    {
        for (int i = 0; i < 3; i++)
        {
            Draw(player);
        }
    }

    public void MoveToGraveyard(CardController cardController)
    {
        cardController.transform.SetParent(graveyardPos);
        cardController.targetPos = Vector3.zero;
        cardController.moving = true;
        cardController.enabled = true;
        cardController.FlipCard(true);
    }
}