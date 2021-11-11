using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaVirus : MonoBehaviour
{
    private float virusDmg;
    private int virusDuration;
    private float damageCoolDown;
    private bool hasApplied;
    private float period = 1.4f;
    private Collider2D coll;


    private void Awake()
    {
        virusDmg = 0.1f;
        virusDuration = 6;
        damageCoolDown = 0.5f;
        virusDuration = 0;
    }

    private void Update()
    {
        if (hasApplied)
        {
            if (Time.time > damageCoolDown)
            {
                damageCoolDown += period;
                coll.GetComponent<health>().takeDamage(virusDmg);
                virusDuration++;

                if(virusDuration > 10)
                {
                    hasApplied = false;
                    gameObject.SetActive(false);
                }
            }
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {      
            if(hasApplied == false)
            {
                coll = collision;
                hasApplied = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}

