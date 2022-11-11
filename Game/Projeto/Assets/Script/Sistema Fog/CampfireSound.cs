using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireSound : MonoBehaviour
{
    public AudioSource aud; //som da fogueira acessa
    void Start()
    {
        GameObject.Find("/gameController").GetComponent<TextScript>().startCampfire = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            aud.Play();
        }
    }

        private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            aud.Stop();
        }
    }

}
