using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonScripts : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private enemyMovement enemyMove;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyMove = GetComponent<enemyMovement>();
    }

    private void Update()
    {
        //attack();
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > attackCooldown && gameObject.GetComponent<enemyMovement>().playerFound == true && gameObject.GetComponent<enemyHealth>().isDead() == false)
        {
            attack();
        }
    }

    public void attack()
    {
        anim.SetTrigger("attack");
        gameObject.GetComponent<enemyMovement>().enemyAttack();
        print("atk");
        cooldownTimer = 0;

        //pool fireball
        fireballs[findFireball()].transform.position = firePoint.position;
        fireballs[findFireball()].GetComponent<dragonProjectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    public int findFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

}
