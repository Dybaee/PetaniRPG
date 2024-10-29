using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject settingObj1;
    public GameObject settingObj2;
    public GameObject backTO;

    public void OnBackButtonClicked()
    {
        settingObj1.SetActive(false);
        settingObj2.SetActive(false);
        backTO.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackButtonClicked(); 
        }
    }

    public void AppExit()
    {
        Application.Quit();
    }

}
