using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;

    private float cooldownTimer;

    private void attack()
    {
        cooldownTimer = 0;

        arrows[findArrow()].transform.position = firePoint.position;
        arrows[findArrow()].GetComponent<EnemyProjectile>().activateProjectile();
    }

    private int findArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= attackCoolDown)
        {
            attack();
        }
    }


}
