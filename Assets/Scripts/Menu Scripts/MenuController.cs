using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isPaused;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                isPaused = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                isPaused = false;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void ResumeGame()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
