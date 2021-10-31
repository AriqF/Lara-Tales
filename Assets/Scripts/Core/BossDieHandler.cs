using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDieHandler : MonoBehaviour
{
    [SerializeField] GameObject enemyBoss;

    private void Update()
    {
        if (enemyBoss.GetComponent<enemyHealth>().isDead())
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
