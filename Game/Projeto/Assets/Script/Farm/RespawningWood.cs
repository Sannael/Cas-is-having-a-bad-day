using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningWood : MonoBehaviour
{
    public GameObject tree;
    public float respawningTime; //tempo de respawn 
    public bool free = false; //checa se tem arvore

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(free == true)
        {
            StartCoroutine(Respawn(respawningTime, tree));
        }
    }
    private IEnumerator Respawn(float Respawning, GameObject tree)
    {   
        free = false;
        int i = 0;
        while(i < 10)
       {
            if(i == 0)
            {
                yield return new WaitForSeconds(respawningTime);
            }
            else
            {
                yield return new WaitForSeconds(respawningTime /2);
            }

            int res  = Random.Range(0 , 2); //se for 0 nao respawna, se for 1 respawna
            Debug.Log(res);
            if(res == 1 || i == 9)
            {
                Debug.Log("Foi karaio");
                YRespawn(tree);
                i = 10;
            }
            i++;
       } 
    }

    void YRespawn(GameObject tree)
    {
        GameObject newtree = Instantiate(tree, new Vector3(transform.position.x ,transform.position.y ,transform.position.z), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Tree"))
        {
            free = false;
        }

    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Tree"))
        {
            free = true;
        }
    }
}
