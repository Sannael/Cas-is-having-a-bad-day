using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeSmallCollisor : MonoBehaviour
{
    public GameObject native, player, shoot; 
    public Native nativeScript;
    public Axe axeScript;
    public BulletScript bs;
    private PlayerScript ps;

    public AudioSource takeDamageAudio;

    void Start()
    {
        player = GameObject.Find("Player");
        nativeScript = native.GetComponent<Native>();
        axeScript = player.GetComponent<Axe>();
        bs = shoot.GetComponent<BulletScript>();
        ps = player.GetComponent<PlayerScript>();
    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Axe") && ps.action == 1)
        {
            takeDamageAudio.Play();
            nativeScript.health += - axeScript.damage;
            StartCoroutine(TakeDamage());
        }
        if(other.CompareTag("Shoot"))
        {
            nativeScript.health += - bs.damage;
        }
    }

    private IEnumerator TakeDamage()
    {
        int i = 0;
        while(i <2)
        {
            this.GetComponentInParent<SpriteRenderer>().color = new Color32(255, 255, 255, 140); //diminui a opacidade do nativo (pisca)
            yield return new WaitForSeconds(0.12f);
            this.GetComponentInParent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); //aumenta a opacidade do nativo
            yield return new WaitForSeconds(0.12f);
            i++;
        }

    }
}
