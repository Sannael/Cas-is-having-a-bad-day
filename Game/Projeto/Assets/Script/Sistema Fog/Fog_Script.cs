using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog_Script : MonoBehaviour
{
    private bool destFog = false;
    public SpriteRenderer fog;

    void Start()
    {


    }

    void Update()
    {
        if(destFog == true)
        {
            StartCoroutine(DestroyFog(fog));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Campfire")) //quando cria a fogueira proxima a fog, ela é destruida
        {
            destFog = true;
 
        }
    }

    private IEnumerator DestroyFog(SpriteRenderer fog)
    {
        destFog = false;
        for(float i = 0.8f; i > 0; i += -0.1f)
        {
            fog.color = new Color(1f, 1f, 1f, i); // Alterações em SpriteRenderer usam RGB de 0 até 1.
            yield return new WaitForSeconds(0.25f); //tempo para alterar a tranparencia do Fog, até zerar e ele destuir 
        }
        Destroy(this.gameObject);
    }
}
