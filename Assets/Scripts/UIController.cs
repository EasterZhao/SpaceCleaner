using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject panel;
    public Animator animator;
    public Button btn_start;
    public GameObject whitepanel;
    private void Start()
    {
        btn_start.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            animator.SetTrigger("Play");
            Invoke("ShowWhite", 6);
        });
    }
    // Quit application
    public void QuitApplication()
    {

        Application.Quit();
    }

    // Switch to the next scene
    public void ShowWhite()
    {
        whitepanel.SetActive(true);
        Invoke("LoadScene", 2);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}