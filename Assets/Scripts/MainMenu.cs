using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button loadGameHover;

    public Animator anim;
    public GameObject loadObj;

    private void Start()
    {
        loadObj.SetActive(false);
    }

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
        //SceneManager.LoadSceneAsync("Gameplay");
        StartCoroutine(NewGame());
        PlayerPrefs.DeleteAll();
    }

    IEnumerator NewGame()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Gameplay");
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
