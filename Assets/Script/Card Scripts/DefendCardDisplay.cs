using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendCardDisplay : MonoBehaviour {
    public DefendCard card;
    public Text nameText;
    public Text descriptionText;
    public Text defendText;
    public Image cardImage;

    public void Start()
    {
        nameText.text = card.cardName.ToString();
        descriptionText.text = card.description.ToString();
        defendText.text = card.defend.ToString();
        cardImage.sprite = card.image;
    }
}
