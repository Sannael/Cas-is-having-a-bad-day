using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Native : MonoBehaviour
{
   
    private PlayerScript ps;
    public Transform playerPos, housePos, wallPos; //posição do jogador e da casa
    public Transform spearPos; //posição que a lança será criada
    private Axe Axe; //Axe Script
    private BulletScript bls; //scipt do tiro
    //public GameObject shoot, houseObj; //projétil dp player; Casa; lança arremesavel
    public GameObject shoot;
    public GameObject houseObj;
    public Rigidbody2D spear;
    public float spearVel;
    public bool house, player; //qual o foco do inimigo? apenas um por vez
    public bool direita = false;
    [SerializeField] //obriga uma variavel privada aparecer no Inspector
    private float enemyVel;
    public bool throwHouse, throwPlayer; //variavel para q o inimigo arremesse (ou não) uma lança tanto no player qnt na casa somente na primeira faz que colidir com elas
    public int health = 60; //vida inicial do inimigo
    public Animator animator;
    public bool inCombat = false, move = true, atk = false;
    public EnemyIdentificator enemyIdent;
    public AudioSource dieAudio;
    private bool alive = true;
    private house houseScript;
    void Start()
    {
        Axe = GameObject.Find("/Player").GetComponent<Axe>();
        bls = shoot.GetComponent<BulletScript>();
        house = GameObject.Find("/====Environment===============/house_0");
        houseScript = GameObject.Find("/====Environment===============/house_0").GetComponent<house>();
        housePos = houseObj.GetComponent<Transform>();
        house = true;
        player = false;
        enemyIdent = gameObject.GetComponentInChildren<EnemyIdentificator>();
        throwHouse = true;
        throwPlayer = true;
        dieAudio = GameObject.Find("/Sounds and musics/NativeDied").GetComponent<AudioSource>();
    }

    void Update()
    {

        player = enemyIdent.player;
        house = enemyIdent.house;
        ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
        playerPos = GameObject.Find("/Player").GetComponent<Transform>();


        if(house == true && animator.GetBool("Attack") == false && inCombat == false && move == true && alive == true) //alvo = casa
        {
            GoToHouse();
        }
        if(player == true && animator.GetBool("Attack") == false && inCombat == false && move == true && alive == true) //alvo = player
        {
            GoToPlayer();
        }
        if(health <= 0)
        {
            StartCoroutine(Die());
        }

    }
    private IEnumerator Die() 
    {
        alive = false;
        animator.SetBool("Move",false);
        animator.SetBool("Attack",false);
        animator.SetBool("Throw",false);
        animator.SetBool("Die", true);
        transform.position = transform.position;
        if(dieAudio != null)
        {
            dieAudio.Play();
        }
        yield return new WaitForSeconds(0.37f);
        Destroy(this.gameObject);

    }

    public void GoToHouse()
    {
        animator.SetBool("Move", true);
        Vector3 housePosition = housePos.position; //armazena os valores da localizaçao da casa 
        housePosition[1] = transform.position[1]; //altera o valor de Y para o mesmo do próprio inimigo para q ele não tente chegar até o mesmo Y da casa, evitando bugs de fisica
        transform.position = Vector2.MoveTowards(transform.position, housePosition, enemyVel * Time.deltaTime);
        Direction(housePos); //checa e altera a direção do inimigo se necessario  
        if(atk == true)
        {
            StartCoroutine(Attack());
        }  
    }

    public void GoToPlayer()
    {
        animator.SetBool("Move", true);
        Vector3 playerPosition = playerPos.position; //armazena a localização do player
        playerPosition[1] = transform.position[1]; //altera o valor de Y do player pro mesmo q o do inimigo para n dar bug de fisica
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, enemyVel * Time.deltaTime);
        Direction(playerPos); //checa e altera a direção do inimigo se necessario
        if(atk == true)
        {
            StartCoroutine(Attack());
        }          
    }

    public void Direction(Transform foco)
    {
        if((transform.position[0] < foco.position[0] && direita == true) || (transform.position[0] > foco.position[0] && direita == false))
        {
            direita = !direita;
            transform.Rotate(0f, 180 ,0f); //espelha o nativo
        }
    }

    public IEnumerator Attack()
    {
        while(atk == true)
        {
        inCombat = true; //em combate o nativo npode andar e nem jogar a lança
        move = false;
        animator.SetBool("Move", false); //para a movimentação
        animator.SetBool("Attack", true); //começa a animação de ataque
        yield return new WaitForSeconds(0.15f);
        animator.SetBool("Attack", false); //fim do ataque
        yield return new WaitForSeconds(1.7f);
        }
        inCombat = false; //pode andar e/ou jogar a lança
        move = true;   
        animator.SetBool("Attack", false); 
    }

    public IEnumerator Throw(Transform alvo, bool foco)
    {
        if(houseScript.houseLife >= 5)
        {
            if(foco == true)
            {
                int i = Random.Range(0,4);
                Debug.Log(i);
                if(i == 0)
                {      
                    animator.SetBool("Throw", true);
                    animator.SetBool("Move", false);
                    move = false;
                    Spear();
                    yield return new WaitForSeconds(0.25f);
                    animator.SetBool("Throw", false);
                    yield return new WaitForSeconds(0.5f);
                    move = true;
                    foco = false;
                }
                else
                {
                    foco = false;
                }
            }
        }
        foco = false;
        yield return 0;
    }

    public void Spear()
    {
        Transform playerPosCurrent = playerPos;
        Rigidbody2D rb = Instantiate(spear, spearPos.position, spearPos.rotation);
    }    

    private void OnBecameVisible() 
    {
        GameObject.Find("/gameController").GetComponent<TextScript>().startEnemy = true;
    }
}
