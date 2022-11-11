using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScript : MonoBehaviour
{
    public bool dest;
    void Start()
    {
        dest = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dest == true)
        {
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
