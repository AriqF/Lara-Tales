using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastBoss_movement : enemyFollowPlayer
{
    public int _moveSpeed;
    public float _attackRadius;

    public bool playerFound;
    public bool attackMode;
    private float trX;
    private float trY;

    //movement
    public float _followRadius;
    [SerializeField] Transform playerTransform; //player object
    [SerializeField] Animator enemyAnim;
    SpriteRenderer enemySR;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private LayerMask groundLayer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Start()
    {
        //get the player transform
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();


        //enemy animation and sprite renderer
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
        //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);

        trX = gameObject.transform.localScale.x;
        trY = gameObject.transform.localScale.y;
    }

    private void Update()
    {
        if (gameObject.GetComponent<lastBoss_Scripts>().lowHP())
            setMoveSpeed(7);

        if (checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            if (playerTransform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-trX, trY, 1);
                //StartCoroutine(Invunerability());
                playerFound = true;
                if (checkAttackRadius(playerTransform.position.x, transform.position.x, playerTransform.position.y, transform.position.y))
                {
                    enemyAttack();
                }
                else
                {
                    if (gameObject.GetComponent<enemyHealth>().currentHealth > 0)
                        this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0.0f, 0.0f);

                    enemyAttack();
                    enemyAnim.SetBool("CanWalk", true);
                }
            }
            //if player behind the enemy
            else if (playerTransform.position.x > transform.position.x)
            {

                transform.localScale = new Vector3(trX, trY, 1);
                playerFound = true;
                if (checkAttackRadius(playerTransform.position.x, transform.position.x, playerTransform.position.y, transform.position.y))
                {
                    enemyAttack();
                }
                else
                {
                    if (gameObject.GetComponent<enemyHealth>().currentHealth > 0)
                        this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0.0f, 0.0f);

                    enemyAttack();
                    enemyAnim.SetBool("CanWalk", true);
                }
            }
        }
        else
        {
            enemyAnim.SetBool("CanWalk", false);
        }
        if (isGrounded())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
            print(" ground");
        }
        else
        {
            body.gravityScale = 1;
            print("not ground");
        }
    }
    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public void enemyAttack()
    {
        attackMode = true;
    }

    public void enemyStopAttack()
    {
        attackMode = false;
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSeconds(2); 
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
