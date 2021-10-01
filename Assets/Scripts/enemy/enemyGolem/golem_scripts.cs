using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem_scripts : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject swordHitBox;

    private Animator anim;
    private golemMovement enemyMove;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyMove = GetComponent<golemMovement>();
    }

    private void Update()
    {
        //attack();
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > attackCooldown && gameObject.GetComponent<golemMovement>().playerFound == true && gameObject.GetComponent<enemyHealth>().isDead() == false)
        {
            attack();
        }
    }

    private void attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
    }
}
