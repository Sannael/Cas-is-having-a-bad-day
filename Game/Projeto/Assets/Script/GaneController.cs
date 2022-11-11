using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaneController : MonoBehaviour
{

    public GameObject[] Light2D = new GameObject[4]; //0 mais claro; 3 mais escuro
    public GameObject fadeBackground;

    public Animator day, night;
    public Animator lamp;
    public bool isDay;
    public int dayCount;
    public float NightTime = 75f, DayTime= 45f, currentTime =0; //ciclo dia e noite; contador de segundos.
    public AudioSource[] aud = new AudioSource[2]; 
    private PlayerScript ps;

    private Spawner SpawnerSL; //SpawnerScript esquerda
    private Spawner SpawnerSR; //SpawnerScript direita

    void Start()
    {
        StartCoroutine(DestroyFade());
        isDay = true;
        dayCount = 1;
        ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
    }

    void Update()
    {

        SpawnerSL = GameObject.Find("/SpawnerLeft").GetComponent<Spawner>();
        SpawnerSR = GameObject.Find("/SpawnerRight").GetComponent<Spawner>();

        currentTime += Time.deltaTime;

        if(isDay == true)
        {
            if(currentTime >= DayTime)
            {
                isDay = false;
                lamp.SetBool("Lamp on", true);
            }
        }
        else
        {
            if(currentTime>= DayTime + NightTime)
            {
                isDay = true;
                lamp.SetBool("Lamp on", false);
                NextDay();
                currentTime = 0;
            }
        }

        if(currentTime >= 39 && currentTime <= 40)
        {
            StartCoroutine(FadeInNight());
        }
        if(currentTime >= 113 && currentTime <= 114)
        {
            StartCoroutine(FadeInDay());
        }
    }

    private IEnumerator DestroyFade()
    {
        yield return new WaitForSeconds(0.45f);
        Destroy(fadeBackground);
    }
    private void NextDay()
    {   
        SpawnerSL.difficulty ++;
        SpawnerSR.difficulty ++;
        ps.health +=  SpawnerSL.difficulty + 8;
    }

    private IEnumerator FadeInDay() //transcição audio do dia
    {
        night.SetBool("FadeOut", true);
        yield return new WaitForSeconds(4f);
        day.SetBool("FadeOut", false);
        
        
    }

    private IEnumerator FadeInNight() //transição audio da noite
    {
        day.SetBool("FadeOut", true);
        yield return new WaitForSeconds(4f);
        night.SetBool("FadeOut", false);        
    }

}
