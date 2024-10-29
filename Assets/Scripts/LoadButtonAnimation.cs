using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButtonAnimation : MonoBehaviour
{
    public Button loadButton; // Reference to the load button
    public Animator loadButtonAnimator; // Reference to the button's animator component

    void Start()
    {
        // Check if saved data exists
        if (PlayerPrefs.HasKey("RespawnX"))
        {
            // Enable the load button animation if there's saved data
            loadButtonAnimator.SetBool("HasSave", true);
            loadButton.interactable = true; // Make the button interactable
        }
        else
        {
            // Disable the load button animation if no saved data
            loadButtonAnimator.SetBool("HasSave", false);
            loadButton.interactable = false; // Make the button non-interactable
            loadButton.GetComponent<Text>().color = Color.gray; // Set a neutral color for no save
        }
    }

    public void LoadGame()
    {
        FindObjectOfType<SaveSystem>().LoadSave();
    }
}
