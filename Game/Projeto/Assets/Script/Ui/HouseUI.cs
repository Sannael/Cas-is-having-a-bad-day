using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseUI : MonoBehaviour
{
    public GameObject houseCollisor, House, Right, Left, HouseIcon;
    public Transform PlayerPos, HousePos;
    private HouseLife His;
    private house Hs;
    private int HouseLifeCurrent, HouseLife; //Atual e apos sofrer dano
    public Sprite[] spriteHouse;
    public Image houseImg;
    public bool canTakeDamage;
    public int tomaNoCu =0;

    void Start()
    {
        HouseIcon.SetActive(false);
        Right.SetActive(false);
        Left.SetActive(false);
        canTakeDamage = true;


        His = houseCollisor.GetComponent<HouseLife>();
        Hs = House.GetComponent<house>();

        HouseLifeCurrent = Hs.houseLife;
        HouseLife  = Hs.houseLife;
    }

    void Update()
    {
        if(Hs.stageHouse == 0)
        {
            houseImg.sprite = spriteHouse[0];
        }

        if(Hs.stageHouse == 1)
        {
            houseImg.sprite = spriteHouse[1];
        }

        if(Hs.stageHouse == 2)
        {
            houseImg.sprite = spriteHouse[2];
        }

        if(Hs.stageHouse == 3)
        {
            houseImg.sprite = spriteHouse[3];
        }

        HouseLifeCurrent = Hs.houseLife;

        if(His.houseInside == false)
        {
            if(PlayerPos.position.x < HousePos.position.x)
            {
                HouseInLeft();
                if(HouseLifeCurrent < HouseLife)
                { 
                    if(tomaNoCu ==0)
                    {
                        SeFude(Right);
                    }
                }
                else
                {
                    Right.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
            }
            else
            {
                HouseInRight();
                if(HouseLifeCurrent < HouseLife && canTakeDamage == true)
                {
                    if(tomaNoCu ==0)
                    {
                        SeFude(Left);
                    }
                }
                else
                {
                    Right.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }


            }
        }
        else
        {
            HouseInside();
            HouseLife = HouseLifeCurrent;
        }
    }

    void HouseInside()
    {
        tomaNoCu =0;
        HouseIcon.SetActive(false);
        Left.SetActive(false);
        Right.SetActive(false);
    }

    void HouseInRight()
    {
        HouseIcon.SetActive(true);
        Left.SetActive(true);
    }

    void HouseInLeft()
    {
        HouseIcon.SetActive(true);
        Right.SetActive(true);
    }

    void SeFude(GameObject Side)
    {
        tomaNoCu ++;
        StartCoroutine(HouseTakeDamage(Side));
    }

    public IEnumerator HouseTakeDamage(GameObject Side) //seta que indica a direção da casa pisca na cir vermelha
    {   
        while(His.houseInside == false) 
        { 
            Debug.Log("FDs");
            Side.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(0.7f);
            Side.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.7f);  
        }
    }
}
