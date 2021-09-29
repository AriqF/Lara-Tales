using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem_scripts : enemies
{
    public float moveSpeed;
    public float timer; //Jeda Waktu Attack

    private float distance; //Menyimpan jarak player dan musuh
    private bool attackMode;
    private bool inRange; //cek player dijarak
    private bool cooling; //cek musuh cooling habis serang
    private float intTimer;
    public bool playerFound;
    private float trX;
    private float trY;

    //movement
    public float _followRadius;
    [SerializeField] Transform playerTransform; //player object
    [SerializeField] Animator anim;
    SpriteRenderer enemySR;

    private void Awake()
    {
        intTimer = timer; //menyimpan inisialisasi timer
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            if (playerTransform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-trX, trY, 1);
                playerFound = true;
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    Attack();
                    print("player found");
                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0.0f, 0.0f);
                    Attack();
                    print("player found");
                    anim.SetBool("CanWalk", true);
                }
            }
            //if player behind the enemy
            else if (playerTransform.position.x > transform.position.x)
            {

                transform.localScale = new Vector3(trX, trY, 1);
                playerFound = true;
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    Attack();
                    print("player found");
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0.0f, 0.0f);
                    Attack();
                    print("player found");
                    anim.SetBool("CanWalk", true);
                }
            }
        }
        else
        {
            anim.SetBool("CanWalk", false);
        }
    }

    void Attack()
    {
        timer = intTimer; //reset timer ketika player masuk area attack
        attackMode = true; //cek musuh bisa nyerang atau tidak

        anim.SetBool("CanWalk", false);
        anim.SetBool("Attack", true);
    }

}
