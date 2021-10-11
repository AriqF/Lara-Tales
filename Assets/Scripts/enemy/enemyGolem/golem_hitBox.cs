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

    public void setDamage(float _damage)
    {
        damage = _damage;
    }

    private void DeactiveHitBox()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if enemy has collision with player
        if (collision.tag == "Player")
        {
            collision.GetComponent<health>().takeDamage(damage);
        }
    }

}
