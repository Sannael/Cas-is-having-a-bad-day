using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] //Mostrar a variavel no inspector, mesmo sendo privada 
    private GameObject spawnerLocate;

    [SerializeField] 
    private GameObject lanceiro;

    [SerializeField]
    private float lanceiroIntervalMin = 3f, lanceiroIntervalMax = 5f; //Cooldown de spawn do inimigo 1

    [SerializeField]
    private bool isDay; //confirma se ta de dia
    [SerializeField]
    private int dayCount; //pega infomação sobre qual dia é (01,02,03......)
    
    [SerializeField]
    private bool wave = false; //checa se esta sob ataque das waves (will make sense :v)

    [SerializeField]
    private GaneController gcs;

    public int difficulty = 1; //Dificuldade da gameplay

    public bool isVisible;
    void Start()
    {
        gcs = GameObject.Find("/gameController").GetComponent<GaneController>();  //pega script de controle do jogo para pegar as infos: ta de dia e qual dia  
        isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        isDay = gcs.isDay;

        if(isDay == true)
        {
            wave = false; //de dia não haveram ataques /reset da condição de estar sob ataque para poder chamar a função de spawn de novo
        }

        if(wave == false)
        {
            Spawn();
        }

    }

    private void Spawn() //função que começa o sistema de spawn 
    {
        if(isDay == false)
            {   
                wave = true; //se estiver em wave, não vai repetir a função até amanhecer e então anoitecer de novo 
                StartCoroutine(SpawnEnemy(lanceiroIntervalMin, lanceiroIntervalMax, lanceiro, spawnerLocate));
            }
        
    }

    private IEnumerator SpawnEnemy(float intervalMin, float intervalMax, GameObject enemy, GameObject Spawner)
    {
        int i = 0;
        while ((i < difficulty))
        {
            float j = Random.Range(intervalMin, intervalMax);
            yield return new WaitForSeconds(j); //intervalo de spawn do inimigo X
            GameObject newEnemy = Instantiate(enemy, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y ,Spawner.transform.position.z), Quaternion.identity);
            i ++;
        }
    }

    private void OnBecameVisible() 
    {
        isVisible = true;   
    }

    private void OnBecameInvisible() 
    {
        isVisible = false;    
    }
}
