using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{

    public GameObject woodWall;
    public bool empty = true;
    public int wood = 4;

    public PlayerScript wps;
    private PauseMenu ps;

    public int GunCount;

    public bool ok = false; 
    public GameObject obj = null;


    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("/gameController").GetComponent<PauseMenu>();
        wps = GameObject.Find("/Player").GetComponent<PlayerScript>();
        GunCount = wps.gunCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(obj != null)
        {
            if(obj.GetComponent<BuildLife>().life <= 0)
            {
                empty = true;
            }

        }
        

        wps = GameObject.Find("/Player").GetComponent<PlayerScript>();
        GunCount = wps.gunCount;

        if(Input.GetKeyDown(KeyCode.E))
        { 

            if(ok == true)
            {
                if(empty == true)
                {
                    if(wps.woodCount >= wood)
                    {
                        if(ps.isPaused == false)
                        {
                            BuildWall();
                        }
                    }
                        
                }
                    
            }

        } 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            if(GunCount == 2)
            { 
                ok = true;

            }

        }
        

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ok = false;
            
        }
        
    }

    void BuildWall()
    {
        obj = Instantiate(woodWall, transform.position, transform.rotation);
        empty = false;
        wps.woodCount += - wood;
        gameObject.SetActive(false);
    }

}