using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    public bool isVisible;

    void Start()
    {
        isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {        
    }
    private void OnBecameVisible() 
    {
      isVisible = true;   
    }

    private void OnBecameInvisible() 
    {
        isVisible = false;
    }
}
