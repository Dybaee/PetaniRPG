using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class QuestTutorial : MonoBehaviour
{
    public GameObject tutorialStatus;
    public GameObject tutorialObj;
    public Animator anim;
    public bool enough = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void UpdateStatus()
    {
        if (enough)
        {
            StartCoroutine(AnimDelay());
        }
    }

    public void OnHit()
    {
        enough = true;
        UpdateStatus();
    }

    IEnumerator AnimDelay()
    {
        tutorialStatus.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("Ceklist");

        yield return new WaitForSeconds(5.5f);
        tutorialObj.gameObject.SetActive(false);
    }
}
