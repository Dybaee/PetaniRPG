using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPCTrigger : MonoBehaviour
{

    private Quest2Ceklist quest2;
    public GameObject fPress;
    private MonoBehaviour PlayerAttackingState;

    public GameObject dialogSystem;
    public MonoBehaviour playerMovementScript;
    public MonoBehaviour dialogueScript;
    private bool InRange;

    // Start is called before the first frame update
    void Start()
    {
        fPress.SetActive(false);
        quest2 = GetComponent<Quest2Ceklist>();
    }

    void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.F))
        {
            if (dialogSystem != null)
            {
                dialogueScript.enabled = true;
                bool dialogActive = !dialogSystem.activeSelf;
                dialogSystem.SetActive(dialogActive);

                PlayerAttackingState.enabled = false;
                playerMovementScript.enabled = !dialogActive;
            }
        }
    }

    // Update is called once per frame
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
            fPress.SetActive(false);
            InRange = false;
            if (dialogSystem != null && dialogSystem.activeSelf)
            {
                dialogSystem.SetActive(false);
                playerMovementScript.enabled = true;
                dialogueScript.enabled = false;
            }
        }
    }
}
