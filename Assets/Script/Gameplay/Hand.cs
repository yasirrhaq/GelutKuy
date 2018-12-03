using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public Deck deck;

    public List<CardYasir> cards;
    public List<GameObject> cardObjects;

    public Transform[] cardPos;

    public void Draw()
    {
        cards.Add(deck.Draw());
        GameMaster.gm.CreateCard(cards[0], deck.transform, cardPos[0], cardObjects);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Draw();
        }
	}
}
