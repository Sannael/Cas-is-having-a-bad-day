using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    
    public static PlayerScript instance;
    public int woodCount;
    public float speed;
    public Animator anim;
    public bool direita = true;
    public float direcao;
    public Camera cam;
    public Vector3 posMouse;
    public GameObject gun;
    private Rigidbody2D rb;
    public int action = 0; //ação que o player estiver fazendo; 0 = nada; 1 = batendo; 2 = interagindo
    public int swap = 0; //marca qual ferramenta o player estava usando antes de trocar "swap" pra arma
    public ToolBox tb; //script da caixa de ferramentas
    private house houseS; //HouseScript
    private bool camp = false; //checa colisão com fogueiras apagas e acessas
    private PauseMenu ps;
    public GameObject handAxe;
    private Animator animAxe;
    public int health;
    private bool canMove;
    public bool canBuild = false;
    public GameObject attackOj;

    public AudioSource damageAudio;

    private bool canTakeDmg = true; 
    //Armas
    public int gunCount; 

    private void Awake() 
    {
        instance = this;   
    }
    
    void Start()
    {
        ps = GameObject.Find("/gameController").GetComponent<PauseMenu>();
        canMove = true;
        gunCount = 1;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animAxe = handAxe.GetComponent<Animator>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        tb = GameObject.Find("/ToolBox").GetComponent<ToolBox>();
        houseS = GameObject.Find("/====Environment===============/house_0").GetComponent<house>(); //salve script da house (caminho até ela)

    if(health > 100)
    {
        health = 100;
    }
        move();

        if(Input.GetMouseButton(1) && ps.isPaused == false)
        {
            if(gunCount != 0)
            {
                swap = gunCount;
                gunCount = 0;
            }
        }

        if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.E) && ps.isPaused == false)
        {
            if(gunCount == 0)
            {
                gunCount = swap;
                swap = 0;
            }
        }

        if (gunCount == 0)
        {
            gun.SetActive(true);
            shoot();
        }             

        if (gunCount == 1)
        {
            if(Input.GetMouseButtonDown(0) && action == 0 && ps.isPaused == false) //se o action n for 0, o castor esta fazendo algma outra ação
            { 
                StartCoroutine(AxeAttack());
            } 

            else if(Input.GetKeyDown(KeyCode.E) && action == 0 && tb.change == false && houseS.buildHouse == false && camp == false && ps.isPaused == false)
            {
                StartCoroutine(AxeInteraction());
            }
        }

        direcao = Input.GetAxis("Horizontal");

        if((direcao >0 && direita) || (direcao <0 && !direita))
        {
            direita = !direita;
            transform.Rotate(0f, 180, 0f);
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(3);
            Destroy(this.gameObject);
        }
    }

    private void TakeDamage(GameObject enemy)
    {
        if(canTakeDmg == true)
        {
            StartCoroutine(CanTakeDamage(enemy));
        }
    }

    IEnumerator CanTakeDamage(GameObject enemy)
    {
        int damage = enemy.GetComponent<Damage>().damage; //dano do inimigo q o atacou
        canTakeDmg = false;
        health += - damage;
        damageAudio.Play();
        int i = 0;
        while(i <3)
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 140); //diminui a opacidade do player (pisca)
            yield return new WaitForSeconds(0.25f);
            this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); //aumenta a opacidade do player
            yield return new WaitForSeconds(0.25f);
            i++;
        }
        canTakeDmg = true;
    }

    void HideAllWeapons()
    {

    }
    void move()
    {
        if (canMove == true && ps.isPaused == false)
        {
            float movement = Input.GetAxisRaw("Horizontal")*speed;        
            float x = Input.GetAxis ("Horizontal");
            Vector3 move = new Vector3 (x * speed, rb.velocity.y, 0f);
            rb.velocity = move; 
            anim.SetFloat("Running", Mathf.Abs(movement));
        }             
    } 

    void shoot()
    {
        posMouse = cam.ScreenToWorldPoint(Input.mousePosition);
        posMouse.z = transform.position.z;
        gun.transform.right = (posMouse - transform.position);        
    }


    IEnumerator AxeAttack() 
    {   
        action = 1;
        canMove = false;
        animAxe.SetTrigger("hitAxe");
        anim.SetTrigger("hitAxe");
        Debug.Log("Atacou");
        yield return new WaitForSeconds(0.5f);
        canMove = true;
        action = 0;
    }

    IEnumerator AxeInteraction() //interação, mesma coisa do ataqu porém não causa dano a inimigos
    {   
        action = 2;
        canMove = false;
        animAxe.SetTrigger("hitAxe");
        anim.SetTrigger("hitAxe");
        Debug.Log("Interação");
        yield return new WaitForSeconds(0.5f);
        canMove = true;
        action = 0;
    }    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("CampfireEmpty"))
        {
            camp = true;
        }
        
        if(other.CompareTag("EnemyAtk"))
        {
            TakeDamage(other.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("CampfireEmpty"))
        {
            camp = false;
        }  
    }

}
