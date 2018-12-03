using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName ="Card")]
public class CardYasir : ScriptableObject {
    public Sprite cardSprite;
    public int cardId;
    public int cardValue;
    public CardType cardType;
}

public enum CardType
{
    punch,
    kick,
    lowDef,
    normalDef,
    highDef,
    heal,
    ultimate
}
