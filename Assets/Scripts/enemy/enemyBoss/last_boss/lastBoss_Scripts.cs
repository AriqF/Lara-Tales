using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastBoss_Scripts : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject hitBox;

    private Animator anim;
    private bossGolemMovement enemyMove;
    private float cooldownTimer = Mathf.Infinity;
    private float currHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyMove = GetComponent<bossGolemMovement>();

    }

    private void Update()
    {
       cooldownTimer += Time.deltaTime;
        if (lowHP())
        {
            attackCooldown = 2.7f;
            hitBox.GetComponent<lastBoss_hitBox>().setDamage(1.5f);
        }

        if (cooldownTimer > attackCooldown && gameObject.GetComponent<lastBoss_movement>().playerFound == true && gameObject.GetComponent<enemyHealth>().isDead() == false)
        {
            if (lowHP())
                attack2();
            else
                attack1();
        }
    }

    public bool lowHP()
    {
        if (gameObject.GetComponent<enemyHealth>().currentHealth <= 3)
            return true;
        else
            return false;
    }

    private void attack1()
    {
        anim.SetTrigger("attack1");
        cooldownTimer = 0;
    }
    private void attack2()
    {
        anim.SetTrigger("attack2");
        cooldownTimer = 0;
    }
}
