using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireTraps : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActiveFireTrap());
            }
            if (active)
            {
                collision.GetComponent<health>().takeDamage(damage);
            }
        }
    }

    private IEnumerator ActiveFireTrap()
    {
        triggered = true;
        spriteRend.color = Color.red;

        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activationDelay);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
