using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform barrel;
    public float fireRate;
    public GameObject bullet;
    public int ammo;
    public float reloadingTiming;
    private float fireTimer;
    public bool noAmmo = false, reloading = false; //checa se tem munição; se esta recarregando
    private PlayerScript ps;
    private SpriteRenderer gunner;
    public float i;
    public PauseMenu psScript;

    public AudioSource[] Aud = new AudioSource[3]; // disparo; atirar sem munição; fim do reloading
    // Start is called before the first frame update
    void Start()
    {
        gunner = GetComponent<SpriteRenderer>();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        psScript = GameObject.Find("/gameController").GetComponent<PauseMenu>();
        ps = GameObject.Find("Player").GetComponent<PlayerScript>();

        if(ps.gunCount == 0)
        {
            gunner.enabled = true;
        }
        else
        {
            gunner.enabled = false;
        }
        Shooting();
                
        if(noAmmo == true)
        {
            noAmmo = false;
            reloading = true;
            StartCoroutine(ReloadingTime());  
        }
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            ammo = 0;
        }
    }

    void Shooting()
    {
        if (ammo == 0 && reloading == false)
        {
            noAmmo = true;                  
        }
        if(Input.GetMouseButton(1) && CanShoot() && psScript.isPaused == false)
        {
            while(ammo >0)
            {
            fireTimer = Time.time + fireRate;
            Aud[0].Play();
            Instantiate(bullet, barrel.position, barrel.rotation);
            ammo += -1;
            break;
            }

            while(ammo <=0)
            {
                Aud[1].Play();
                break;
            }

        }
    }
    IEnumerator ReloadingTime()
    {
        i = reloadingTiming;
        while(i > 0)
        {
            yield return new WaitForSeconds(1);
            i --;
        } 
        Aud[2].Play();
        ammo = 7;
        reloading = false;
        i = 0;
    }


    private bool CanShoot()
    {
        return Time.time > fireTimer;
    } 

}
