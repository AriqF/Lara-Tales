using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSword : MonoBehaviour
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
        //if enemy has collision with enemy
        if (collision.tag == "enemy")
        {
            collision.GetComponent<enemyHealth>().takeDamage(damage);
        }
        if(collision.tag == "enemyProjectile")
        {

        }
    }

    private void DeactiveSword()
    {
        gameObject.SetActive(false);
    }
}
