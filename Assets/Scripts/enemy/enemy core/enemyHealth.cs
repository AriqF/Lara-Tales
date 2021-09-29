using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [Header("Enemey Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("Enemy iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberofFlashes;
    private SpriteRenderer enemySpriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        enemySpriteRend = GetComponent<SpriteRenderer>();
    }

    public void takeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //enemy hurt   
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {           
                anim.SetTrigger("die");
                dead = true;
            }

        }
    }

    public bool isDead()
    {
        if (dead)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        //Invunerability duration

        for (int i = 0; i < numberofFlashes; i++)
        {
            enemySpriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 3)); //2s / numberofFlashes (3) *2 = 0.33s
            enemySpriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 3));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

        //if (dead)
        //{
        //    yield return new WaitForSeconds(1);
        //    gameObject.SetActive(false);
        //}
    }
}
