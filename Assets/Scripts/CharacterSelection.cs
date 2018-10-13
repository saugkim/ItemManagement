using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    public List<GameObject> CharacterItemCanvases;
    public List<GameObject> CharacterSkillCanvases;

    public List<Button> CharacterButtons;
    
    int setChar;
   
	void Start () {

        for (int i = 0; i < CharacterItemCanvases.Count; i++)
        {
            CharacterItemCanvases[i].SetActive(false);
        }
        for (int i = 0; i < CharacterSkillCanvases.Count; i++)
        {
            CharacterSkillCanvases[i].SetActive(false);
        }

        for (int i = 0; i < CharacterButtons.Count; i++)
        {
            CharacterButtons[i].transform.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Character"+ (i+1));
        }

        setChar = 0;
	}

    public void SelectCharacter(int selectedCharacter)
    {
        for (int i = 1; i <= CharacterItemCanvases.Count; i++)
        {
            if(selectedCharacter == i)
            {
                setChar = i;
            }
        }
    }

    public void OpenItemManagementPanel()
    {
        this.gameObject.SetActive(false);

        for (int i = 0; i < CharacterItemCanvases.Count; i++)
        {

            if (setChar == (i+1))
            {
                CharacterItemCanvases[i].SetActive(true);
            }
            else
            {
                CharacterItemCanvases[i].SetActive(false);
            }
        }

        for (int i = 1; i <= CharacterSkillCanvases.Count; i++)
        {
            CharacterSkillCanvases[i].SetActive(false);
        }
    }

    public void OpenSkillManagementPanel()
    {
        this.gameObject.SetActive(false);

        for (int i = 0; i < CharacterSkillCanvases.Count; i++)
        {
            if (setChar == (i + 1))
            {
                CharacterSkillCanvases[i].SetActive(true);
            }
            else
            {
                CharacterSkillCanvases[i].SetActive(false);
            }
        }
    }
}