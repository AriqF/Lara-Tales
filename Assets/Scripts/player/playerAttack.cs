using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] private float fireballAttackCooldown;
    [SerializeField] private float swordAttackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject swordHitBox;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private bool enableFireballSkill;


    private Animator anim;
    private playerMovement PlayerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private float comboCoolDown;


    private void Awake()
    {   
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<playerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && cooldownTimer > swordAttackCooldown && PlayerMovement.canAttack())
        {
            if (PlayerMovement.isGrounded())
            {
                swordAtk1();
            }
               
            else if (!PlayerMovement.isGrounded() && !PlayerMovement.onWall())
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 7;
                jumpAtk();
            }
                
        }

        if (Input.GetKey(KeyCode.E) && cooldownTimer > fireballAttackCooldown && PlayerMovement.canAttack() && 
             enableFireballSkill == true && PlayerMovement.isGrounded())
        {
            castFireball();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void swordAtk1()
    {
        anim.SetTrigger("swordAtk");
        cooldownTimer = 0;
    }

    private void jumpAtk()
    {
        anim.SetTrigger("jumpAtk");      
        cooldownTimer = 0;
    }

    private void castFireball()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //pool fireball
        fireballs[findFireball()].transform.position = firePoint.position;
        fireballs[findFireball()].GetComponent<projectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int findFireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
