using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLife : MonoBehaviour
{
    public int life = 3;
    public BuildScript bs;
    public GameObject buildArea, obj = null;
    private Vector3 thisTransform;
    public AudioSource buildAudio;
    private AudioSource damageAudio;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BuildSound());
        thisTransform  = transform.position;
        thisTransform[1] = -3.87f;
        damageAudio = GameObject.Find("/Sounds and musics/TreeDamage").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(life <= 0)
        {
            obj = Instantiate(buildArea, thisTransform, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.CompareTag("EnemyAtk"))
        {
            damageAudio.Play();
            life --;
        } 
    }

    public IEnumerator BuildSound()
    {
        int i = 0;
        while(i <4)
        {
            buildAudio.Play();
            yield return new WaitForSeconds(0.15f);
            i ++;
        }
    }

}