using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLife : MonoBehaviour
{
    private bool takeDamage = true;
    public Native nativeScript;
    public bool houseInside;
    public AudioSource houseDamage;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("EnemyAtk"))
        {
            StartCoroutine(TakeDamage(other.gameObject));
        }
    }

    IEnumerator TakeDamage(GameObject native)
    {
        houseDamage.Play();
        nativeScript = native.GetComponentInParent<Native>();
        if(nativeScript != null)
        {
            if(nativeScript.house == true)
            {
                if(takeDamage == true)
                {
                    takeDamage = false;
                    this.GetComponentInParent<house>().houseLife --;
                }
                yield return new WaitForSeconds(0.2f);
                takeDamage = true;
            }
        }
        else
        {
            takeDamage = false;
            this.GetComponentInParent<house>().houseLife --;
            yield return new WaitForSeconds(0.2f);
            takeDamage = true;
        }
        yield return 0;
    }    
    
    private void OnBecameVisible() 
    {
      houseInside = true; 
    }

    private void OnBecameInvisible()
    {
        houseInside = false;
    }
}
