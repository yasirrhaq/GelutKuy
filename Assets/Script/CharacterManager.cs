using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour {

    public GameObject[] listChar;
    private int index;

    private void Start()
    {
        listChar = new GameObject[transform.childCount];

        // Isi array character
        for(int i = 0; i < transform.childCount; i++)
        {
            listChar[i] = transform.GetChild(i).gameObject;
        }

        // hide character
        foreach (GameObject go in listChar)
        {
            go.SetActive(false);
        }
        // activer character ter awal
        if (listChar[0])
        {
           listChar[0].SetActive(true);
        }
    }

    public void PanahKiri()
    {
        // non aktif current char
        listChar[index].SetActive(false);


        index--;
        if (index < 0 )
        {
            index = listChar.Length - 1;
        }

        // aktif current char
        listChar[index].SetActive(true);
    }

    public void PanahKanan()
    {
        // non aktif current char
        listChar[index].SetActive(false);


        index++;
        if (index == listChar.Length)
        {
            index = 0
;
        }

        // aktif current char
        listChar[index].SetActive(true);
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("BattleScene");
    }
}
