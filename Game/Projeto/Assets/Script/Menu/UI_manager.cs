using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_manager : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI txtWood, txtAmmo, AmmoConfig, WoodConfig; //cotador de madeira; contador de munição, configuração do contador de munição//madeira (color da fonte)
    public Image imgItem;
    public GameObject gun;

    public Sprite[] img;
 
    //public GameObject txtWoodGO;
    private PlayerScript ps; 
    private GunScript gs;


    // Start is called before the first frame update
    void Start()
    {
        AmmoConfig = txtAmmo.GetComponent<TextMeshProUGUI>();
        WoodConfig = txtWood.GetComponent<TextMeshProUGUI>();
        ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
        gs = gun.GetComponent<GunScript>();
        //imgItem = gameObject.GetComponent<Image>();
        //a
    }

    // Update is called once per frame
    void Update()
    {
        if(ps.gunCount == 1)
        {
            imgItem.sprite = img[1];
        }
        else if(ps.gunCount == 2)
        {
            imgItem.sprite = img[2];
        }

        if(ps.woodCount > 0)
        {
            WoodConfig.color = Color.white;
        }
        else
        {
            WoodConfig.color = Color.red;
        }

        if(gs.ammo > 1)
        {
            AmmoConfig.color = Color.white;
        }
        else
        {
            AmmoConfig.color = Color.red;
        }
        if(gs.ammo > 0)
        {
            AmmoConfig.fontSize = 30;
            txtAmmo.text = gs.ammo.ToString();
        }
        else
        {  
            txtAmmo.text = "";
            slider.value = gs.i;
        }

        txtWood.text = ps.woodCount.ToString();        
    }
}
