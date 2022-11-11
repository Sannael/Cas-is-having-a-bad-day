using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdentificator : MonoBehaviour
{
    private PlayerScript ps;
    private Transform playerPos, housePos, wallPos; //posição do jogador e da casa
    public Native nativeScript; 
    public GameObject houseObj;

    public bool house, player; //qual o foco do inimigo? apenas um por vez

    public bool throwHouse, throwPlayer; //variavel para q o inimigo arremesse (ou não) uma lança tanto no player qnt na casa somente na primeira faz que colidir com elas

    public BoxCollider2D identification;
    void Start()
    {
        houseObj = GetComponentInParent<Native>().houseObj;
        housePos = houseObj.GetComponent<Transform>();
        house = true;
        player = false;
        identification = gameObject.GetComponent<BoxCollider2D>();
        throwHouse = true;
        throwPlayer = true;
    }

    void Update()
    {
        playerPos = GameObject.Find("/Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            house = false;
            player = true;
            if(nativeScript.throwPlayer == true && player == true)
            {
                StartCoroutine(nativeScript.Throw(nativeScript.playerPos, nativeScript.throwPlayer));
                nativeScript.throwPlayer = false;
            }
        }
        else if(other.CompareTag("HouseCollisor"))
        {
            if(player == false)
            {
                house = true;
                if(nativeScript.throwHouse == true && house == true)
                {
                    StartCoroutine(nativeScript.Throw(nativeScript.housePos, nativeScript.throwHouse));
                    nativeScript.throwHouse = false;
                }
            }
        }
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Wall")) //se destuir a barricada volta o foco para a casa
        {  
            StartCoroutine(ExtendCollisor());
        }

        if(other.CompareTag("Player") && player == true) //se o player sair da area de detecção, volta o foco para a casa
        {
            player = false;
            house = true;
        }
    }
    IEnumerator ExtendCollisor()
    {
        for (int i = 4; i < 18; i++)
        {
            identification.size = new Vector2(i, identification.size.y);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
