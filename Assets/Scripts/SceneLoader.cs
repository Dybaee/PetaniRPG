using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // string currentScene = SceneManager.GetActiveScene().name;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // public void SceneReloader()
    // {
    //     SceneManager.LoadScene(currentScene);
    // }
}
