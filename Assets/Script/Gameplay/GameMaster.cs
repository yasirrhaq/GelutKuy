using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    public static GameMaster gm;
    public GameObject cardPrefab;
    public Deck deck;
    public Hand hand;
    public Graveyard graveyard;
    public StatusController playerStatus;

    public Deck deckOppo;
    public Hand handOppo;
    public Graveyard graveyardOppo;
    public StatusController oppoStatus;

    public GameOver gameOverController;

    public Turn gameTurn;
    public Phase gamePhase;

    public float turnDelay = 2f;

    float timer;

    bool delay;
    bool clearBoard;
    bool recycleCards;

    private void Awake()
    {
        gm = this;
    }

    private void Start()
    {
        deck.Shuffle();
        deckOppo.Shuffle();

        playerStatus.UpdateHealthUI();
        playerStatus.UpdateDeckUI();

        oppoStatus.UpdateHealthUI();
        oppoStatus.UpdateDeckUI();

        hand.Draw3(true);
        handOppo.Draw3(false);
    }

    private void Update()
    {
        //ngatur delay
        if (delay)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                delay = false;
            }
            return;
        }

        //recycle card
        if (recycleCards)
        {
            if (!hand.recycled)
            {
                if (deck.cardIds.Count <= 0)
                {
                    graveyard.RecycleCards();
                }

                if (deckOppo.cardIds.Count <= 0)
                {
                    graveyardOppo.RecycleCards();
                }
            }
            else
            {
                if (deck.graveCardControllers.Count <= 0)
                {
                    graveyard.RecycleCards();
                }

                if (deckOppo.graveCardControllers.Count <= 0)
                {
                    graveyardOppo.RecycleCards();
                }
            }

            recycleCards = false;
            WaitingAction();
            return;
        }

        if (!gameOverController.gameOver)
        {
            //move to graveyard
            if (clearBoard)
            {
                hand.MoveToGraveyard(hand.battleCard);
                handOppo.MoveToGraveyard(handOppo.battleCard);

                if (!hand.recycled)
                {
                    if (deck.cardIds.Count <= 0)
                    {
                        recycleCards = true;
                    }

                    if (deckOppo.cardIds.Count <= 0)
                    {
                        recycleCards = true;
                    }
                }
                else
                {
                    if (deck.graveCardControllers.Count <= 0)
                    {
                        recycleCards = true;
                    }

                    if (deckOppo.graveCardControllers.Count <= 0)
                    {
                        recycleCards = true;
                    }
                }

                clearBoard = false;
                WaitingAction();
                return;
            }

            //kalkulasi battle phase
            if (gamePhase == Phase.Battle)
            {
                hand.battleCard.FlipCard(true);
                handOppo.battleCard.FlipCard(true);

                int playerBattleStat = 0;
                int opponentBattleStat = 0;
                int result = 0;

                switch (hand.battleCard.cardType)
                {
                    case CardType.attack:
                        playerBattleStat = hand.battleCard.cardValue;
                        break;
                    case CardType.defence:
                        playerBattleStat = -hand.battleCard.cardValue;
                        break;
                    case CardType.heal:
                        hand.health += hand.battleCard.cardValue;
                        break;
                    //case CardType.ultimate:
                    //    break;
                    default:
                        break;
                }

                switch (handOppo.battleCard.cardType)
                {
                    case CardType.attack:
                        opponentBattleStat = handOppo.battleCard.cardValue;
                        break;
                    case CardType.defence:
                        opponentBattleStat = -handOppo.battleCard.cardValue;
                        break;
                    case CardType.heal:
                        handOppo.health += handOppo.battleCard.cardValue;
                        break;
                    //case CardType.ultimate:
                    //    break;
                    default:
                        break;
                }

                if (playerBattleStat > 0 && opponentBattleStat > 0)
                {
                    hand.health -= opponentBattleStat;
                    handOppo.health -= playerBattleStat;
                }
                else if (playerBattleStat > 0 && opponentBattleStat <= 0)
                {
                    result = playerBattleStat + opponentBattleStat;
                    if (result > 0)
                    {
                        handOppo.health -= result;
                    }
                    else if (result < 0)
                    {
                        hand.health -= Mathf.Abs(result);
                    }
                }
                else if (playerBattleStat <= 0 && opponentBattleStat > 0)
                {
                    result = opponentBattleStat + playerBattleStat;
                    if (result > 0)
                    {
                        hand.health -= result;
                    }
                    else if (result < 0)
                    {
                        handOppo.health -= Mathf.Abs(result);
                    }
                }
                gamePhase = Phase.Draw;
                clearBoard = true;
                WaitingAction(1f);

                playerStatus.UpdateHealthUI();
                oppoStatus.UpdateHealthUI();
                Debug.Log("HP Kita : " + hand.health + " HP Musuh : " + handOppo.health);
                if (hand.health <= 0)
                {
                    gameOverController.GameOverCondition(false);
                }
                else if (handOppo.health <= 0)
                {
                    gameOverController.GameOverCondition(true);
                }
                return;
            }

            //turn base
            if (gameTurn == Turn.Player)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    switch (gamePhase)
                    {
                        case Phase.Draw:
                            hand.Draw(true);
                            gamePhase = Phase.Main;
                            hand.ToggleSelector(true);
                            break;
                        case Phase.Main:
                            hand.ToggleSelector(false);
                            hand.MoveToBattlePos();
                            hand.Rearrange();
                            gameTurn = Turn.Opponent;
                            gamePhase = Phase.Draw;
                            break;
                        default:
                            break;
                    }
                    WaitingAction();
                }
                if (gamePhase == Phase.Main)
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        hand.NextCard();
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        hand.PrevCard();
                    }
                }
            }
            else
            {
                switch (gamePhase)
                {
                    case Phase.Draw:
                        handOppo.Draw(false);
                        gamePhase = Phase.Main;
                        break;
                    case Phase.Main:
                        int random = Random.Range(0, handOppo.cardControllers.Count);
                        handOppo.selectedIndex = random;
                        handOppo.MoveToBattlePos();
                        handOppo.Rearrange();
                        gameTurn = Turn.Player;
                        gamePhase = Phase.Battle;
                        break;
                    default:
                        break;
                }
                hand.ChangeSelectorPosition(0);
                WaitingAction();
            }
        }
    }

    public void CreateCard(CardYasir cardInfo, Transform startPos, Transform cardPos, List<CardController> cardList)
    {
        //GameObject newCard = Instantiate(cardPrefab, startPos);
        //newCard.transform.SetParent(cardPos);

        GameObject newCard = Instantiate(cardPrefab);
        SetCardMovement(cardInfo, newCard, startPos, cardPos, cardList);
    }

    public void SetCardMovement(CardYasir cardInfo, GameObject newCard, Transform startPos, Transform cardPos, List<CardController> cardList, bool render = true)
    {
        newCard.transform.SetParent(startPos);
        newCard.transform.localPosition = Vector3.zero;
        newCard.transform.SetParent(cardPos);
        
        CardController newCardController = newCard.GetComponent<CardController>();
        newCardController.enabled = true;

        cardList.Add(newCardController);

        newCardController.targetPos = new Vector3((cardList.Count - 1) * 1.5f, 0, 0);
        newCardController.moving = true;

        if (render)
        {
            RenderCard(cardInfo, newCardController);
        }
    }

    public void RenderCard(CardYasir cardInfo, CardController card)
    {
        card.cardId = cardInfo.cardId;
        card.cardValue = cardInfo.cardValue;
        card.cardSprite.sprite = cardInfo.cardSprite;
        card.cardType = cardInfo.cardType;
    }

    public void WaitingAction(float addTime = 0)
    {
        timer = turnDelay + addTime;
        delay = true;
    }
}

public enum Phase{
    Draw,
    Main,
    Battle,
    }

public enum Turn
{
    Player,
    Opponent
}