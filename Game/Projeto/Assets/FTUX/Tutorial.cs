using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Animator[] tutorial = new Animator[11];
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            TutorialText(tutorial[0]);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
           TutorialText(tutorial[1]); 
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
           TutorialText(tutorial[2]); 
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
           TutorialText(tutorial[3]); 
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
           TutorialText(tutorial[4]); 
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
           TutorialText(tutorial[5]); 
        }

        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
           TutorialText(tutorial[6]); 
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
           TutorialText(tutorial[7]); 
        }

        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
           TutorialText(tutorial[8]); 
        }

        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
           TutorialText(tutorial[9]); 
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
           TutorialText(tutorial[10]); 
        }
    }

    private void TutorialText(Animator animator)
    {
        if(animator.GetBool("Start") == true)
        {
            animator.SetBool("Start", false);
        }
        else
        {
            animator.SetBool("Start", true);
        }
        
    }

}
