using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject dialogBox;
    public string[] lines;
    public float textSpeed;
    public float fastTextSpeed; // Speed when speeding up the animation
    public bool isActive;
    private bool canNextLine;
    private int index;
    private bool isSkipping;
    //public MonoBehaviour PlayerStateMachine;

    private void Start()
    {
        
    }

    public void StartSequence()
    {
        ResetDialog();
        dialogBox.SetActive(true);
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canNextLine)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                isSkipping = true;
            }
        }
    }

    void ResetDialog()
    {
        index = 0;
        textComponent.text = string.Empty;
        canNextLine = false;
        isSkipping = false;
    }

    void StartDialogue()
    {
        isActive = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        canNextLine = false;
        isSkipping = false;

        string currentLine = lines[index];
        for (int i = 0; i < currentLine.Length; i++)
        {
            textComponent.text = currentLine.Substring(0, i + 1);

            if (Input.GetMouseButtonDown(0))
            {
               
                textComponent.text = currentLine;
                yield return null;
                break;
            }

            yield return new WaitForSeconds(isSkipping ? fastTextSpeed : textSpeed);
        }

        canNextLine = true;
        isSkipping = false; 
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogBox.SetActive(false);
            //gameObject.SetActive(false);
            isActive = false;
        }
    }
}
