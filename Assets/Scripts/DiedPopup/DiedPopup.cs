using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedPopup : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PopUp()
    {
        StartCoroutine(AnimPopup());
    }

    private IEnumerator AnimPopup()
    {
        anim.SetTrigger("Popup");
        yield return new WaitForSeconds(0.5f); 
    }
}
