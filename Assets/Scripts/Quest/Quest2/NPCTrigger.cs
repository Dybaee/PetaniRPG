using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPCTrigger : MonoBehaviour
{
    private Quest2Ceklist quest2;
    public GameObject fPress;

    public GameObject dialogSystem;
    public MonoBehaviour PlayerStateMachine;
    public MonoBehaviour dialogueScript;
    private bool InRange;

    // Start is called before the first frame update
    void Start()
    {
        fPress.SetActive(false);
        quest2 = GetComponent<Quest2Ceklist>();
        PlayerStateMachine = FindObjectOfType<PlayerStateMachine>().GetComponent<MonoBehaviour>();
    }

    void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (dialogSystem != null)
            {
                bool dialogActive = !dialogSystem.activeSelf;
                dialogSystem.SetActive(dialogActive);

                if (dialogActive)
                {
                    // Disable movement and attacking when dialog is active
                    PlayerStateMachine.enabled = false;
                    dialogueScript.enabled = true;
                }
                else
                {
                    // Re-enable movement and attacking when dialog ends
                    PlayerStateMachine.enabled = true;
                    dialogueScript.enabled = false;
                }
            }
        }

        // Update is called once per frame
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(Urutan());
            }
        }

        IEnumerator Urutan()
        {
            InRange = true;
            fPress.SetActive(true);
            quest2.Find();
            yield break;
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                fPress.SetActive(false);
                InRange = false;
                if (dialogSystem != null && dialogSystem.activeSelf)
                {
                    dialogSystem.SetActive(false);
                    dialogueScript.enabled = false;
                }
            }
        }

    }
}
