using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public static GameMaster gm;
    public GameObject cardPrefab;
    // Use this for initialization

    private void Awake()
    {
        gm = this;
    }

    public void CreateCard(CardYasir cardInfo, Transform startPos, Transform cardPos, List<GameObject> cardList)
    {
        GameObject newCard = Instantiate(cardPrefab, startPos);
        newCard.transform.SetParent(cardPos);
        CardController newCardController = newCard.GetComponent<CardController>();
        newCardController.enabled = true;

        newCardController.targetPos = Vector3.zero;
        newCardController.moving = true;

        cardList.Add(newCard);
        RenderCard(cardInfo, newCardController);
    }

    public void RenderCard(CardYasir cardInfo, CardController card)
    {
        card.cardId = cardInfo.cardId;
        card.cardValue = cardInfo.cardValue;
        card.cardSprite.sprite = cardInfo.cardSprite;
        card.cardType = cardInfo.cardType;
    }
}
