using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossGolemMovement : enemyFollowPlayer
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
        if (checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            if (playerTransform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-trX, trY, 1);
                playerFound = true;
                if (checkAttackRadius(playerTransform.position.x, transform.position.x, playerTransform.position.y, transform.position.y))
                {
                    enemyAttack();
                    print("player found");
                }
                else
                {
                    if(gameObject.GetComponent<enemyHealth>().currentHealth > 0)
                        this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0.0f, 0.0f);

                    enemyAttack();
                    print("player found");
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
                    print("player found");
                }
                else
                {
                    if (gameObject.GetComponent<enemyHealth>().currentHealth > 0)
                        this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0.0f, 0.0f);

                    enemyAttack();
                    print("player found");
                    enemyAnim.SetBool("CanWalk", true);
                }
            }


        }
        else
        {
            enemyAnim.SetBool("CanWalk", false);
        }
    }

    public void enemyAttack()
    {
        attackMode = true;
    }

    public void enemyStopAttack()
    {
        attackMode = false;
    }
}
