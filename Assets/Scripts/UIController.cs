using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Quit application
    public void QuitApplication()
    {

        Application.Quit();
    }

    // Switch to the next scene
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
    }

}