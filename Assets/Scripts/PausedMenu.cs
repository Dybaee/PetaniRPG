using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas; 
    private bool isPaused = false;
    public PlayerStateMachine playerScript;

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f; 
        playerScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false); 
        Time.timeScale = 1f;
        playerScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }
}
