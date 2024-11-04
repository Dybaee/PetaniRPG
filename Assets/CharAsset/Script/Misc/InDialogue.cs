using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class InDialogue : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup;
    [SerializeField] public GameObject dialogSystem;
    [SerializeField] public DialogSystem dialogueScript;
    
    public List<NPCTrigger> NonPlayableCharacters = new List<NPCTrigger>();

    public NPCTrigger CurrentNPC { get; private set; }
    public bool dialogActive;
    private void OnTriggerEnter(Collider other)
    {
        NPCTrigger trigger = other.GetComponent<NPCTrigger>();
        if (trigger == null)
        {
            return;
        }
        NonPlayableCharacters.Add(trigger);
    }

    private void OnTriggerExit(Collider other)
    {
        NPCTrigger trigger = other.GetComponent<NPCTrigger>();
        if (trigger == null)
        {
            return;
        }
        NonPlayableCharacters.Remove(trigger);
    }

    public bool SelectNPC() 
    {
        if(NonPlayableCharacters.Count == 0) 
        {
            return false;
        }

        CurrentNPC = NonPlayableCharacters[0];
        cineTargetGroup.AddMember(CurrentNPC.transform, 1f, 2f);

        return true;
    }

    public void CancelNPC()
    {
        if(CurrentNPC == null) { return; }
        cineTargetGroup.RemoveMember(CurrentNPC.transform);
        CurrentNPC = null;
    }

    public void ToggleDialogue()
    {
        dialogActive = !dialogActive;
        if (dialogSystem != null && dialogueScript.isActive == false)
        {       
            dialogueScript.isActive = true;
            dialogSystem.SetActive(dialogActive);

            if (dialogActive)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                dialogueScript.StartSequence();
            }
        }
        else
        {
            dialogActive = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        //dialogueScript.enabled = false; 
    }
}
