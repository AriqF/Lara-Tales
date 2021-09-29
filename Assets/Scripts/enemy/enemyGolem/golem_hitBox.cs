using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem_hitBox : MonoBehaviour
{
    private bool hit;
    private PolygonCollider2D colliderBox;
    [SerializeField] protected float damage;

    private void Update()
    {
        if (hit) return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if enemy has collision with player
        if (collision.tag == "Player")
        {
            collision.GetComponent<health>().takeDamage(damage);
            print("player hit by golem!");
        }
    }

}
