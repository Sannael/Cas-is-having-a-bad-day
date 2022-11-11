using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBox : MonoBehaviour
{
    public PlayerScript ps;
    public bool change = false;

    public GameObject canvasToolBox;


    void Update()
    {
        if(change == true)
        {      
            ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
            if(Input.GetKeyUp(KeyCode.E))
            { 
                if(ps.gunCount == 2)
                {
                    ps.gunCount = 1;
                }
                else
                {
                    ps.gunCount += 1;
                }                
            }         
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {   

         if(other.CompareTag("Player"))
        {
            canvasToolBox.SetActive(true);
            change = true; 
        }
          
    }

    void OnTriggerExit2D(Collider2D other)
    {

          if(other.CompareTag("Player"))
        {
           canvasToolBox.SetActive(false);
           change = false; 
        }
        
    }
}
