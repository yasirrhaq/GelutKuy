using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour {

    public Slider volume;
    public AudioSource audioSource;

    public void SetVolume()
    {
        audioSource.volume = volume.value;
    }

    private void Update()
    {
        SetVolume();
    }
}
