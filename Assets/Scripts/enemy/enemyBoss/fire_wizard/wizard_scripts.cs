using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizard_scripts : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] firebolts;
    [SerializeField] private GameObject[] cross;
    [SerializeField] private GameObject healthBar;

    private Animator anim;
    private enemyMovement enemyMove;
    private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    private bool isSkillActive;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyMove = GetComponent<enemyMovement>();
        attackCooldown = 2.9f;
    }

    private void Update()
    {
        if (isLowHp())
        {
            attackCooldown = 2.6f;
        }

        if(gameObject.GetComponent<enemyMovement>().playerFound == true && gameObject.GetComponent<enemyHealth>().isDead() == false)
        {
            healthBar.SetActive(true);
        }

        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > attackCooldown && gameObject.GetComponent<enemyMovement>().playerFound == true && gameObject.GetComponent<enemyHealth>().isDead() == false && gameObject.GetComponent<enemyMovement>().attackMode == true)
        {
            if (isLowHp())
            {
                anim.SetTrigger("superAttack");
                StartCoroutine(waitforDelay());
                superAtk();
            }
            else
            {
                anim.SetTrigger("attack");
                StartCoroutine(waitforDelay());
                normalAtk();
            }
            
        }
    }

    private bool isLowHp()
    {
        if (gameObject.GetComponent<enemyHealth>().currentHealth <= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void normalAtk()
    {
        gameObject.GetComponent<enemyMovement>().enemyAttack();
        cooldownTimer = 0;
        firebolts[findFirebolts()].transform.position = firePoint.position;
        firebolts[findFirebolts()].GetComponent<firebolts>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private void superAtk()
    {
        gameObject.GetComponent<enemyMovement>().enemyAttack();
        cooldownTimer = 0;
        cross[findCross()].transform.position = firePoint.position;
        cross[findCross()].GetComponent<cross>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    public int findFirebolts()
    {
        for (int i = 0; i < firebolts.Length; i++)
        {
            if (!firebolts[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    public int findCross()
    {
        for (int i = 0; i < cross.Length; i++)
        {
            if (!cross[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private IEnumerator waitforDelay()
    {
        yield return new WaitForSeconds(2f);
    }
}
