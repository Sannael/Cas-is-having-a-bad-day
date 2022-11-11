using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float spearVel;
    private Transform playerPos;
    public Rigidbody2D rb;
    public BoxCollider2D colliderTrig;
    
    void Start()
    {
        playerPos = GameObject.Find("/Player").GetComponent<Transform>();
        StartCoroutine(ThrowSpear());
    }
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(this.gameObject);
    }
    IEnumerator ThrowSpear()
    {
        float force = Random.Range(8.8f, 10.2f); 
        rb.velocity = transform.up * force;
        rb.velocity = transform.right * force; 
        for(float i = transform.rotation.z; i > -47; i--)
        {
            transform.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.09f);
        } 
        yield return 0;        
    }
}
