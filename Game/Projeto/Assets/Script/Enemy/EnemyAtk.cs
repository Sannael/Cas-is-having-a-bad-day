using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    private Native nativeScript;
    public EnemyIdentificator enemyIdent;
    private bool house = false, wall = false;
    void Start()
    {
        nativeScript = gameObject.GetComponentInParent<Native>();
    }
    void Update()
    {
        if(house == true && enemyIdent.house == false)
        {
            nativeScript.atk = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && nativeScript.inCombat == false)
        {
            nativeScript.atk = true;
            
        }

        else if(other.CompareTag("HouseCollisor") && nativeScript.inCombat == false && nativeScript.house == true)
        {
            nativeScript.atk = true;
            house = true;
           
        }   
        else if(other.CompareTag("Wall") && nativeScript.inCombat == false)
        {
            enemyIdent.identification.size = new Vector2(4, enemyIdent.identification.size.y);
            nativeScript.atk = true;
            wall = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && wall == false)
        {
            nativeScript.atk = false;
        }

        else if(other.CompareTag("HouseCollisor"))
        {
            nativeScript.atk = false;
            house = false;
           
        }   
        else if(other.CompareTag("Wall"))
        {
            nativeScript.atk = false; 
            wall = false;
        }        
    }
}
