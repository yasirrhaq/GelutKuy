using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {
    public int cardId;
    public int cardValue;
    public CardType cardType;
    public SpriteRenderer cardSprite;

    public Vector3 targetPos;

    public float speed = 10;

    public bool moving = false;

    float step;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            step = speed * Vector3.Distance(transform.localPosition, targetPos);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, step * Time.deltaTime);

            if (transform.localPosition == targetPos)
            {
                moving = false;
                this.enabled = false;
            }
        }
	}
}
