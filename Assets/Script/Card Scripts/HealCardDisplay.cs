using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealCardDisplay : MonoBehaviour {
    public HealCard card;
    public Text nameText;
    public Text descriptionText;
    public Text healText;
    public Image cardImage;

    public void Start()
    {
        nameText.text = card.cardName.ToString();
        descriptionText.text = card.description.ToString();
        healText.text = card.heal.ToString();
        cardImage.sprite = card.image;
    }
}
