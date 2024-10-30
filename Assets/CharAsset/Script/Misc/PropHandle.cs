using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropHandle : MonoBehaviour
{
    [SerializeField] private GameObject[] PropItem;

    public void EnableProp()
    {
        foreach (var prop in PropItem)
        {
            prop.SetActive(true);
        }
    }

    public void DisableProp()
    {
        foreach (var prop in PropItem)
        {
            prop.SetActive(false);
        }
    }
}
