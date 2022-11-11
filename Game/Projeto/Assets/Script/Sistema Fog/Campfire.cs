using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    
    public int Wood = 0; //contagem de madeira
    private AudioSource campfireStart; // acendendo a fogueira
    [SerializeField]
    private PlayerScript ps;
    [SerializeField]
    private bool isInside = false; //checa se o player ta perto da fogueira
    [SerializeField]
    private GameObject campfire; //fogueira
    [SerializeField]
    private GameObject campfire_Empty; //fogueira vazia 
    public bool Dest;

    private Spawner SpawnerSL; //SpawnerScript esquerda
    private Spawner SpawnerSR; //SpawnerScript direita

    public int WoodNeed; //quantidade de madeira q precisa pra construir a fogueira

    
    void Start()
    {
        Dest = false;
        ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
        campfireStart = GameObject.Find("/Sounds and musics/Campfire").GetComponent<AudioSource>();    
    }

    void Update()
    {
        SpawnerSL = GameObject.Find("/SpawnerLeft").GetComponent<Spawner>();
        SpawnerSR = GameObject.Find("/SpawnerRight").GetComponent<Spawner>();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isInside == true)
            {
                if(ps.woodCount > 0)
                {
                    Wood ++;
                    ps.woodCount --;
                }

            }
        }

        if(Wood == WoodNeed)
        {
            Dest = true;
            CreateCampfire();
        }

    }

    private void OnDestroy() 
    {
        if(campfireStart != null)
        {
            campfireStart.Play();
        }    
    }
    public void CreateCampfire()
    {
        Instantiate(campfire, new Vector3( campfire_Empty.transform.position.x, campfire_Empty.transform.position.y + 0.1f, campfire_Empty.transform.position.z), Quaternion.identity);
        SpawnerSL.difficulty ++;
        SpawnerSR.difficulty ++;
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {   
            isInside = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {   
            isInside = false;

        }
    }



}
