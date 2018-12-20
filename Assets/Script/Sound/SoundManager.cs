using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip bg;
    public AudioClip draw;
    public AudioClip main;
    public AudioClip battle;
    public AudioClip slide;
    public AudioClip grave;
    public AudioClip win;
    public AudioClip lose;
    public AudioSource background;
    public AudioSource fx;
    public AudioSource pause;


    public void gamePause()
    {
        background.Pause();
        pause.Play();
    }

    public void gameResume()
    {
        background.Play();
        pause.Stop();
    }

    public void playBackground()
    {
        background.clip = bg;
        background.Play();
    }

    public void playDraw()
    {
        fx.clip = draw;
        fx.Play();
    }

    public void playMain()
    {
        fx.clip = main;
        fx.Play();
    }

    public void playBattle()
    {
        fx.clip = battle;
        fx.Play();
    }
    public void playSlide()
    {
        fx.clip = slide;
        fx.Play();
    }
    public void playGrave()
    {
        fx.clip = grave;
        fx.Play();
    }

    public void playWin()
    {
        if (background.isPlaying)
        {
            background.Stop();
        }

        fx.clip = win;
        fx.Play();
    }
    public void playLose()
    {
        if (background.isPlaying)
        {
            background.Stop();
        }

        fx.clip = lose;
        fx.Play();
    }
}
