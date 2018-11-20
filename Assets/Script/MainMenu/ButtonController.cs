using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public void Play(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Berhasil Exit");
    }
}
