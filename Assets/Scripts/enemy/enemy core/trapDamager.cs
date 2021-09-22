using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDamager : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //if trap has collision to player
        if(collision.tag == "Player")
        {
            //get player component from health class
            collision.GetComponent<health>().takeDamage(damage);
        }
    }

  
}
