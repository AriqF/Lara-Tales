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


    private Animator anim;
    private playerMovement PlayerMovement;
    private Rigidbody2D rigid;
    private float cooldownTimer = Mathf.Infinity;
    private bool isBlocking;

    private void Awake()
    {   
        anim = GetComponent<Animator>();
        PlayerMovement = GetComponent<playerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && cooldownTimer > swordAttackCooldown && PlayerMovement.canAttack())
        {
            swordAtk();
        }

        if (Input.GetKey(KeyCode.E) && cooldownTimer > fireballAttackCooldown && PlayerMovement.canAttack() && PlayerMovement.fireSkillUnlocked())
        {
            castFireball();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void swordAtk()
    {
        anim.SetTrigger("swordAtk");
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
