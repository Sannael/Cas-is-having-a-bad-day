using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public int lifeWood = 5;
    public ParticleSystem leafParticle;
    public GameObject leafP;
    public GameObject woodDrop;
    public PlayerScript ps;

    [SerializeField]
    private int woodMin = 5;
    [SerializeField]
    private int woodMax = 10;
    public float RespawningTime = 1f; //tempo de respawn 
    public AudioSource treeDamage;
    private GameObject leaf;

    void Start()
    {
        Vector3 leafPos = transform.position;
        leafPos[0] += -0.33f;
        leafPos[1] = 0.03f;
        leaf = Instantiate(leafP, leafPos, Quaternion.identity);
        leafParticle = leaf.GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {

        ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
        if(lifeWood <= 0 )
        {
            leaf.GetComponent<LeafScript>().dest = true;
            int quant = Random.Range(woodMin, woodMax);
            Destroy(this.gameObject);
            for(int i = 0; i < quant; i++)
            {
                Instantiate(woodDrop, transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.CompareTag("Axe") && ps.action == 2) //Só pode "atacar" a arvore com a interação
        {
            treeDamage.Play();
            lifeWood--;
            leafParticle.Play();
        }  
    }


}
