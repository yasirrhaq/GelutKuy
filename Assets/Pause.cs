using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    public SoundManager sound;
    public static bool pause;
    public GameObject pauseImage;
    public GameObject resume;
    public GameObject exitToDesktop;
    public GameObject exitToMainMenu;
    public GameObject background;
   


    // Use this for initialization
    void Start () {
        pause = false;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("pause: " + pause);
            if (pause)
            {
                gameResume();
            }
            else
            {
                gamePause();
            }
        }
    }

    public void gamePause()
    {
        if (pause == false)
        {
            pauseImage.SetActive(true);
            resume.SetActive(true);
            exitToDesktop.SetActive(true);
            exitToMainMenu.SetActive(true);
            background.SetActive(true);
            sound.gamePause();
            pause = true;
            
            Time.timeScale = 0;
        }
    }

    public void gameResume()
    {
        if (pause == true)
        {
            pauseImage.SetActive(false);
            resume.SetActive(false);
            exitToDesktop.SetActive(false);
            exitToMainMenu.SetActive(false);
            background.SetActive(false);
            sound.gameResume();
            pause = false;
            Time.timeScale = 1;
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Berhasil Exit");
    }

}
