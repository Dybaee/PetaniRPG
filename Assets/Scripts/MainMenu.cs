using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button loadGameHover;


    private void Awake()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            loadGameButton.interactable = false;
        }
    }

    public void OnNewGameClicked()
    {
        //DataPersistenceManager.Instance.NewGame();
        SceneManager.LoadSceneAsync("Gameplay");
        PlayerPrefs.DeleteAll();
    }

    public void OnLoadGameClicked()
    {
        //DataPersistenceManager.Instance.LoadGame();
        SceneManager.LoadSceneAsync("Gameplay");
    }

    public void OnSaveGameClicked()
    {
        DataPersistenceManager.Instance.SaveGame();
    }

    //private void DisableMenuButtons()
    //{
    //    newGameButton.interactable = false;
    //    loadGameButton.interactable = false;
    //}
}
