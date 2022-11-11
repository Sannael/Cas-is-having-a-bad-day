using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dicas : MonoBehaviour
{
    public GameObject wall, tree, Hammer, Camp;
    public bool isWall, isCampfire, isTree;
    private bool alrearyDoneWall, alrearyDoneTree, empty;
    public TextMeshProUGUI WoodNeed, CampWood, Wood, WoodNeedConfig; 
    public GameObject cm, ba;
    private Campfire cms;
    private BuildScript bs;
    private PlayerScript ps;

    void Start() 
    {
        ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
        empty = true;
    }

    void Update()
    {
        if(empty == true)
        {
            if(isWall)
            {
                WoodNeedConfig = WoodNeed.GetComponent<TextMeshProUGUI>();
                bs = ba.GetComponent<BuildScript>();
                WoodNeed.text = bs.wood.ToString();
                if(ps.woodCount >= bs.wood)
                {
                    WoodNeedConfig.color = Color.white;
                }
                else
                {
                    WoodNeedConfig.color = Color.red;
                }
            }
        }

        if(isCampfire)
        {
            if(cm != null)
            {
                cms = cm.GetComponent<Campfire>();
                if(cms.Dest == false)
                {
                CampWood.text = cms.Wood.ToString() + "/" + cms.WoodNeed.ToString();
                }
            }
        }

        if(Camp != null)
        {
            if(cm == null)
            {
                Camp.SetActive(false);
            }        
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            if(isWall)
            {
                empty = false;
                wall.SetActive(false);
            }
        }
        else if(other.CompareTag("Player") && empty)
        {
            if(isWall && !alrearyDoneWall)
            {
                Hammer.SetActive(true);
                alrearyDoneWall=true;
            }
            else if (!alrearyDoneTree && isTree)
            {
               
                tree.SetActive(true);
                alrearyDoneTree=true; 
            }
            if(isWall)
            {
                wall.SetActive(true);
            }   
            if(isCampfire)
            {
                Camp.SetActive(true);  
                Hammer.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            if(isWall)
            {
                empty = true;
            }
        }
        if(other.CompareTag("Player"))
        {
            if(isWall)
            {
                wall.SetActive(false);
                Hammer.SetActive(false);
            }
            else if(isTree)
            {
                tree.SetActive(false);
            }
            else
            {
                Camp.SetActive(false);
            }
        }
        if(other.CompareTag("Tree"))
        {
            tree.SetActive(false);
            alrearyDoneTree = true;
        }

        if(other.CompareTag("CampfireEmpty"))
        {
            if(isCampfire)
            {
                Camp.SetActive(false);
                isCampfire = false;
            }
        }

    }
}
