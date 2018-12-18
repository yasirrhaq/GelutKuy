using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour {

    public List<GameObject> listCharacter;
    public List<GameObject> characters;
    public Transform characterPos;
    private int index;

    private void Start()
    {
        index = 0;
        characters = new List<GameObject>();
        GetCharacter();
        HideCharacter();

        characters[0].SetActive(true);
    }
    
    private void GetCharacter()
    {
        foreach (GameObject character in listCharacter)
        {
            characters.Add(Instantiate(character, characterPos.position, Quaternion.identity));
        }
    }

    private void HideCharacter()
    {
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }
    }

    public void SelectPrev()
    {
        characters[index].SetActive(false);
        index--;

        if (index < 0)
        {
            index = characters.Count - 1;
        }
        characters[index].SetActive(true);
    }

    public void SelectNext()
    {
        characters[index].SetActive(false);
        index++;

        if (index == characters.Count)
        {
            index = 0;
        }
        characters[index].SetActive(true);
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("Character Selected", index);
        SceneManager.LoadSceneAsync("Gameplay");
    }
}