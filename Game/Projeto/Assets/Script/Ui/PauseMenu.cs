using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, pnC, pnM, texts;
    public Animator animQuit;
    public bool isPaused;
    public AudioSource aud;

    void Start()
    {
        isPaused = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                Pause();
            }
            else
            {
                Resume();
                Sure(false);
            }
        }   
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pnC.SetActive(false);
        pnM.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToPanel(GameObject panel)
    {
        Sure(false);
        panel.SetActive(true);
    }

    public void BackToPause(GameObject panel)
    {
        Sure(false);
        panel.SetActive(false);
    }

    public void ClickSound()
    {
        aud.Play();
    }

    public void Sure(bool up)
    {
        if(up == true)
        {
            animQuit.SetBool("Up", true);
            animQuit.SetBool("Down", false);
        }
        else
        {
            animQuit.SetBool("Up", false);
            animQuit.SetBool("Down", true);
        }
    }
}
