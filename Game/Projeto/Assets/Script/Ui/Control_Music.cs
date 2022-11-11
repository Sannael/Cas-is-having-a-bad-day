using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Music : MonoBehaviour
{
    public GameObject pnM, pnC; //panel de music; control
    public Animator animQuit;

    public void BackToMenu(GameObject panel)
    {
        Sure(false);
        panel.SetActive(false);
    }  
    public void ToSettings(GameObject panel)
    {
        Sure(false);
        panel.SetActive(true);
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
