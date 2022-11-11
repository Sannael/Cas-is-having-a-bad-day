using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float duration, bulletSpeed;
    public bool travel; 
    public int damage;

    void Start()
    {   
        Destroy(gameObject, duration);
        travel=true;
        
    }

    void Update()
    {
        if(travel)
        {
            transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player") && !other.CompareTag("Finish"))
        {
            travel = false;
        }
        if(other.CompareTag("FogCollisor") || other.CompareTag("SmallCollisor") || other.CompareTag("EnemyAtk"))
        {
            Destroy(gameObject);
        }

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
