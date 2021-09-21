using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : enemies 
{
    public int _moveSpeed;
    public int _attackDamage;
    public int _lifePoints;
    public float _attackRadius;

    public bool playerFound;

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
        setAttackDamage(_attackDamage);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
    }

    private void Update()
    {
        if(checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            if(playerTransform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                playerFound = true;
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    enemyAttack();
                    print("player found");

                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0.0f, 0.0f);
                    enemyAttack();
                    print("player found");
                    enemyAnim.SetBool("walk", true);
                    
                    //enemySR.transform.localScale = new Vector3(1, 1, 1);
                    //enemySR.flipX = false;
                }
            }
            //if player behind the enemy
            else if(playerTransform.position.x > transform.position.x)
            {

                transform.localScale = new Vector3(1, 1, 1);
                playerFound = true;
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    enemyAttack();
                    print("player found");
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0.0f, 0.0f);
                    enemyAttack();
                    print("player found");
                    enemyAnim.SetBool("walk", true);             
                    //enemySR.transform.localScale = new Vector3(-1, 1, 1);
                    //enemySR.flipX = true;
                }
            }
        }
        else
        {
            enemyAnim.SetBool("walk", false);
        }
    }

    public void enemyAttack()
    {
        
    }
}
