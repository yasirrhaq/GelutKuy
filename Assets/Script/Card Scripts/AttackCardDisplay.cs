using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCardDisplay : MonoBehaviour {
    public AttackCard card;
    public Text nameText;
    public Text descriptionText;
    public Text attackText;
    public Image cardImage;

    public void Start()
    {
        nameText.text = card.cardName.ToString();
        descriptionText.text = card.description.ToString();
        attackText.text = card.attack.ToString();
        cardImage.sprite = card.image;
    }
}
