using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : trapDamager //inherit from enemyDamager class
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    public void activateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if(lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2Ds(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); //execute logic from parent (enemeyDamager class)
        if (collision.tag == "Ground" || collision.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
        gameObject.SetActive(false); //deactive object on Hit
    }
}
