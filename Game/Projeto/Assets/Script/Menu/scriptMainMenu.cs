using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMainMenu : MonoBehaviour
{   
    public AudioSource aud; //Click nos botões
    public Animator animTutorial, animQuit, gameAnim, txtGameAnim;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Credits")
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(SkipCredits());
            }
            StartCoroutine(CreditsToMainMenu());
        }

        if(SceneManager.GetActiveScene().name == "Game Win")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(SkipToCredits());
            }
            StartCoroutine(GoToCredits());    
        }
        if(SceneManager.GetActiveScene().name == "Game Over")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(SkipToMainMenu());
            }
            StartCoroutine(GoToMainMenu());
        }
        if(SceneManager.GetActiveScene().name == "Game Start")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StopAllCoroutines();
                StartCoroutine(SkipToGame());
            }
            StartCoroutine(GoToGame());
        }
    }
    /*  Cena 0 Main Menu
        Cena 1 Creditos
        Cena 2 Jogo
        Cena 3 Game Over
        Cena 4 Game Win
        Cena 5 Game Start
        Cena 6 Tutorial
    */
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator GoToCredits()
    {
        yield return new WaitForSeconds(29.5f);
        gameAnim.SetBool("Fade Out", true);
        txtGameAnim.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.5f);
        LoadScene(1); 
    }

        public IEnumerator SkipToCredits()
    {
        gameAnim.SetBool("Fade Out", true);
        txtGameAnim.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.5f);
        LoadScene(1);
    }

    public IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(29.5f);
        gameAnim.SetBool("Fade Out", true);
        txtGameAnim.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.5f);
        LoadScene(0); 
    }
    public IEnumerator SkipToMainMenu()
    {
        gameAnim.SetBool("Fade Out", true);
        txtGameAnim.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.5f);
        LoadScene(0);
    }

    public IEnumerator CreditsToMainMenu()
    {
        yield return new WaitForSeconds(29.5f);
        gameAnim.SetBool("Fade In", true);
        yield return new WaitForSeconds(0.5f);
        LoadScene(0); 
    }
    public IEnumerator SkipCredits()
    {
        gameAnim.SetBool("Fade In", true);
        yield return new WaitForSeconds(0.5f);
        LoadScene(0);
    }

    
    public IEnumerator GoToGame()
    {
        yield return new WaitForSeconds(29.5f);
        gameAnim.SetBool("Fade Out", true);
        txtGameAnim.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.5f);
        LoadScene(2);
    }

    public IEnumerator SkipToGame()
    {
        gameAnim.SetBool("Fade Out", true);
        txtGameAnim.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.5f);
        LoadScene(2);
    }

    public void SoundClick()
    {
        aud.Play();
    }

    public void StartGame()
    {
        animTutorial.SetBool("Start", true);
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
