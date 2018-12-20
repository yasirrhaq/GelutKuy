using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

    public bool gameOver;
    public Image result;
    public GameObject mainMenu;
    public GameObject restart;
    public Sprite winSprite;
    public Sprite loseSprite;

	public void GameOverCondition(bool win)
    {
        result.enabled = true;
        mainMenu.SetActive(true);
        restart.SetActive(true);
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

    public void MainMenu(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
