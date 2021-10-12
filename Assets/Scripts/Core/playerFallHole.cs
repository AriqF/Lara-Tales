using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFallHole : MonoBehaviour
{
    private float damage;
    private bool hit;

    private void Update()
    {
        if (hit) return;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<health>().instantKill();
        }
    }
}
