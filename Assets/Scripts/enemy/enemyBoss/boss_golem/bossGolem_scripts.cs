using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossGolem_scripts : MonoBehaviour
{
    [SerializeField] private float meleeAttackCooldown;
    [SerializeField] private GameObject hitBox;

    private Animator anim;
    private bossGolemMovement enemyMove;
    private float cooldownTimer = Mathf.Infinity;
    private bool launchFire;
    private float currHealth;
    private bool hasUsed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyMove = GetComponent<bossGolemMovement>();
        hasUsed = false;
    }

    private void Update()
    {
        if(hasUsed == false)
        {
            print("hasUsed false");
            if (gameObject.GetComponent<enemyHealth>().currentHealth <= 2)
            {
                print("boss health <= 2");
                anim.SetTrigger("buffArmor");
                StartCoroutine(waitAddition());       
                gameObject.GetComponent<enemyHealth>().addCurrHealth(2);
                hitBox.GetComponent<golem_hitBox>().setDamage(1.5f);
                hasUsed = true;
            }
        }
              
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer > meleeAttackCooldown && gameObject.GetComponent<bossGolemMovement>().playerFound == true && gameObject.GetComponent<enemyHealth>().isDead() == false )
        {
            meleeAttack();
        }
    }

    private void meleeAttack()
    {
        anim.SetTrigger("meleeAttack");
        cooldownTimer = 0;
    }

    private IEnumerator waitAddition()
    {
        yield return new WaitForSeconds(2);
    }

}
