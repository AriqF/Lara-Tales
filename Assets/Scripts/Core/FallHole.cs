using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHole : MonoBehaviour
{
    private bool hits;

    private void Update()
    {
        if (hits) return;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<health>().instantKill();
        }
        if(collision.tag == "enemy")
        {
            print("golem fall");
            collision.GetComponent<enemyHealth>().instantKill();
        }
    }
}
