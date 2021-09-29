using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem_behavior : MonoBehaviour
{
    private const bool Value = false;
    #region Public Variables
    [SerializeField] protected GameObject hitBox;
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Jarak Minimum Attack
    public float moveSpeed;
    public float timer; //Jeda Waktu Attack
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance; //Menyimpan jarak player dan musuh
    private bool attackMode;
    private bool inRange; //cek player dijarak
    private bool cooling; //cek musuh cooling habis serang
    private float intTimer;
    private float trX, trY;
    #endregion

    private void Start()
    {
        trX = transform.localScale.x;
        trY = transform.localScale.y;

    }
    void Awake()
    {
        intTimer = timer; //menyimpan inisialisasi timer
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            RaycastDebugger();

        }

        //ketika player kedetek
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }

        if(inRange == false)
        {
            anim.SetBool("CanWalk", false);
            StopAttack();
        }
        else if(inRange == true)
        {
            anim.SetBool("CanWalk", true);
            Cooldown();
            
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }

    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            hitBox.SetActive(true);
            Attack();
        }

        if(cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (target.transform.position.x < transform.position.y)
            {
                transform.localScale = new Vector3(-trX, trY, 1);
            }
            else if (target.transform.position.x > transform.position.y)
            {
                transform.localScale = new Vector3(trX, trY, 1);
            }
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; //reset timer ketika player masuk area attack
        attackMode = true; //cek musuh bisa nyerang atau tidak

        anim.SetBool("CanWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
