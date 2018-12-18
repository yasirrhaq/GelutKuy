using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public bool gameOver;
    public Image result;
    public Sprite winSprite;
    public Sprite loseSprite;

	public void GameOverCondition(bool win)
    {
        result.enabled = true;
        if (win)
        {
            result.sprite = winSprite;
        }
        else
        {
            result.sprite = loseSprite;
        }
        gameOver = true;
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
