using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalCheckPoint : GameManager
{
    [SerializeField] GameObject enemyBoss;

    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enemyBoss.GetComponent<enemyHealth>().currentHealth <= 0)
        {
            StartCoroutine(base.loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

}
