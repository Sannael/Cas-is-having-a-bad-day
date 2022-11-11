using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    /*
    AxeText 6
    HammerText 6
    PistolText 8
    EnemyText 6
    CampfireText 6
    CaveText 6
    House2Text 6
    House3Text 6
    House4Text 10
    */
    public Animator anim; //animator dos textos
    private bool enemy, campfire, cave, house2, house3, house4; //qual texto já foi; 
    public bool  startCampfire, startEnemy;
    private Native nativeScript;
    private CampfireSound campfireScript;
    public Cave caveLeft, caveRight;
    private house houseScript;
     
     public GameObject native, campfireobj;
    void Start()
    {
        enemy = false;
        campfire = false;
        cave = false;
        house2 = false;
        house3 =  false;
        house4 = false; 
        startCampfire = false;
        startEnemy = false;

        houseScript = GameObject.Find("/====Environment===============/house_0").GetComponent<house>();
        StartCoroutine(FirstTexts());
    }

    void Update()
    {  

        if(caveLeft.isVisible == true && cave == false || caveRight.isVisible == true && cave == false)
        {
            StartCoroutine(Cave());
        }

        if(houseScript.stageHouse == 1 && house2 == false)
        {
            StartCoroutine(House2());
        }

        if(houseScript.stageHouse == 2 && house3 == false)
        {
            StartCoroutine(House3());
        }

        if(houseScript.stageHouse == 3 && house4 == false)
        {
            StartCoroutine(House4());
        }

        if(startCampfire == true && campfire == false)
        {
            StartCoroutine(Campfire());
        }

        if(startEnemy == true && enemy == false)
        {
            StartCoroutine(Enemy());
        }   
    }

    private IEnumerator FirstTexts()
    {
        anim.SetBool("AxeText", true);
        yield return new WaitForSeconds(6f);

        anim.SetBool("AxeText", false);
        anim.SetBool("HammerText", true);
        yield return new WaitForSeconds(6f);

        anim.SetBool("HammerText", false);
        anim.SetBool("PistolText", true);
        yield return new WaitForSeconds(8f);

        anim.SetBool("PistolText", false); 
    }

    public IEnumerator Enemy()
    {
        enemy = true;
        anim.SetBool("EnemyText", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("EnemyText", false);
    }

    public IEnumerator Campfire()
    {
        campfire = true;
        anim.SetBool("CampfireText", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("CampfireText", false);
    }

    private IEnumerator Cave()
    {
        cave = true;
        anim.SetBool("CaveText", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("CaveText", false);
    }

        private IEnumerator House2()
    {
        house2 = true;
        anim.SetBool("House2Text", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("House2Text", false);
    }

        private IEnumerator House3()
    {
        house3 = true;
        anim.SetBool("House3Text", true);
        yield return new WaitForSeconds(6f);
        anim.SetBool("House3Text", false);
    }

        private IEnumerator House4()
    {
        house4 = true;
        anim.SetBool("House4Text", true);
        yield return new WaitForSeconds(10f);
        anim.SetBool("House4Text", false);
    }
}
