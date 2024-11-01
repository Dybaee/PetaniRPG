using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    
    public GameObject fPress;
    public GameObject quest3;

    public GameObject dialogSystem;
    public MonoBehaviour PlayerStateMachine;
    public MonoBehaviour dialogueScript;
    private bool InRange;
    private bool dialogActive;

    // Start is called before the first frame update
    void Start()
    {
        quest3.SetActive(false);
        fPress.SetActive(false);
        dialogSystem.SetActive(false); 
        PlayerStateMachine = FindObjectOfType<PlayerStateMachine>();
        if (PlayerStateMachine == null)
        {
            Debug.LogError("PlayerStateMachine not found");
        }
    }

    void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.F))
        {
            ToggleDialogue();
        }
    }

    private void ToggleDialogue()
    {
        dialogActive = !dialogActive;

        if (dialogSystem != null)
        {
            dialogSystem.SetActive(dialogActive);

            if (dialogActive)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                // PlayerStateMachine.enabled = false;
                dialogueScript.enabled = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                // PlayerStateMachine.enabled = true;
                dialogueScript.enabled = false;
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = true;
            fPress.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InRange = false;
            fPress.SetActive(false);
            quest3.SetActive(true);
            if (dialogActive)
            {
                ToggleDialogue(); 
            }
        }
    }
}
