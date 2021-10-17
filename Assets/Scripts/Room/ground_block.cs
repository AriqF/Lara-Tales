using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_block : MonoBehaviour
{
    [SerializeField] GameObject enemyBoss;

    private void Update()
    {
        if (enemyBoss.GetComponent<enemyHealth>().isDead())
            gameObject.SetActive(false);
    }

}
