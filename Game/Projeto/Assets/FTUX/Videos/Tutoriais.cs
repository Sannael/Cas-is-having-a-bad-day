using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class Tutoriais : MonoBehaviour
{
    public VideoPlayer [] tutorial = new VideoPlayer[10];
    public TextMeshProUGUI back, next;
    public Animator anim;
    private int video = 0;
    private scriptMainMenu sceneScipt;
    void Start()
    {
        TutorialPlayer(video);
        sceneScipt = GameObject.Find("/SceneManager").GetComponent<scriptMainMenu>();
    }

    void Update()
    {
        if(video == 9 && (ulong)tutorial[video].frame == tutorial[video].frameCount -1)
        {
            StartCoroutine(EndOfTutorial());
        }

        if((ulong)tutorial[video].frame == tutorial[video].frameCount -1 && video < 9)
        {
            tutorial[video].Stop();
            video ++;
            StartCoroutine(FadeTutorial(video));
        }

        if(Input.GetKeyDown(KeyCode.A) && video > 0)
        {
            StopAllCoroutines();
            tutorial[video].Stop();
            video --;
            StartCoroutine(FadeTutorial(video));
        }

        if(Input.GetKeyDown(KeyCode.D) && video < 9)
        {
            StopAllCoroutines();
            tutorial[video].Stop();
            video ++;
            StartCoroutine(FadeTutorial(video));
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(EndOfTutorial());
        }

        if(video == 0)
        {
            back.enabled = false;
        }
        else
        {
            back.enabled = true;
        }

        if(video < 9)
        {
            next.enabled = true;
        }
        else
        {
            next.enabled = false;
        }
    }

    private IEnumerator FadeTutorial(int video)
    {
        anim.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.4f);
        TutorialPlayer(video);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Fade In", true);
        anim.SetBool("Fade Out", false);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Fade In", false);
        TutorialPlayer(video);
    }

    private void TutorialPlayer(int video)
    {
        tutorial[video].Play();
    }

    private IEnumerator EndOfTutorial()
    {
        anim.SetBool("Fade Out", true);
        yield return new WaitForSeconds(0.5f);
        sceneScipt.LoadScene(5);
    } 
}
