using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class house : MonoBehaviour
{
    public GameObject lampLeft, lampRight;
    public bool buildHouse;
    public int houseLife;
    public Sprite[] imgList;
    public float countTime;
    private int Dif = 0;//nivel de dificuldade aumentado
    public int stageHouse;

    public GameObject canvasHouse;

    public TextMeshProUGUI txtWood;

    private PlayerScript ps;
    private Spawner SpawnerSL; //SpawnerScript esquerda
    private Spawner SpawnerSR; //SpawnerScript direita

    public AudioSource[] Aud = new AudioSource[1];

    void Start()
    {
        houseLife = 1;
        ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnerSL = GameObject.Find("/SpawnerLeft").GetComponent<Spawner>();
        SpawnerSR = GameObject.Find("/SpawnerRight").GetComponent<Spawner>();

        txtWood.text = houseLife.ToString() + "/100"; 
        
        if(houseLife <= 24)
        {
            stageHouse = 0;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = imgList[0];
        }
        else if(houseLife > 24 && houseLife <= 49)
        {
            stageHouse = 1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = imgList[1];
        }
        else if(houseLife > 49 && houseLife <= 74)
        {
            stageHouse = 2;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = imgList[2];
            lampLeft.transform.position = new Vector3(-3.25f, -3.82f, 0f);
            lampRight.transform.position = new Vector3(2.12f, -3.82f, 0f);
        }  
        else if(houseLife > 74 && houseLife <= 100)
        {
            stageHouse = 3;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = imgList[3];
            lampLeft.transform.position = new Vector3(-3.65f, -3f, 0f);
            lampRight.transform.position = new Vector3(2.6f, -3f, 0f);
        } 

        if(houseLife == 25 && Dif == 0)
        {
            SpawnerSL.difficulty ++;
            SpawnerSR.difficulty ++;
            Dif ++;
            Aud[0].Play();
        }
        if(houseLife == 50 && Dif == 1)
        {   
            SpawnerSL.difficulty ++;
            SpawnerSR.difficulty ++;
            Dif ++;
            Aud[0].Play();
        }
        if(houseLife == 75 && Dif == 2)
        {            
            SpawnerSL.difficulty ++;
            SpawnerSR.difficulty ++;
            Dif ++;
            Aud[0].Play();
        }

        if(buildHouse && Input.GetButton("Jump") && ps.woodCount!=0 && houseLife < 100)
        {
            countTime += Time.deltaTime;
            if(countTime>0.5f)
            {                
                countTime =0;
                ps.woodCount--;
                houseLife += 1;
            }             
        }

        if(houseLife < 1)
        {
            SceneManager.LoadScene(3);
        }
        
        if(houseLife >= 100)
        {
            SceneManager.LoadScene(4);
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canvasHouse.SetActive(true);
            buildHouse = true;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canvasHouse.SetActive(false);
            buildHouse = false;
        }
    }

}
