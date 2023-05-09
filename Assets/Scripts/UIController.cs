using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject panel;
    public Animator animator;
    public GameObject player;

    // Quit application
    public void QuitApplication()
    {

        Application.Quit();
    }

    // Switch to the next scene
    public void ShowWhite()
    {
        
        Invoke("LoadScene", 2);
    }
        public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
        public void LoadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartScene()
    {
            panel.SetActive(false);
            animator.SetTrigger("Play");
            Invoke("ShowWhite", 6);
    }

        public void OnButtonPress()
    {
       player.transform.position = new Vector3(-2f, -0.6f, -4.5f);
    }

}