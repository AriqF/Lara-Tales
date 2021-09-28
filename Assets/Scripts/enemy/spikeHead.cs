using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeHead : trapDamager
{
    [Header("spikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;


    private void OnEnable()
    {
        spikeStop();
    }

    private void Update()
    {
        //move spikehead to destination only if attacking
        if (attacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;
            if(checkTimer > checkDelay)
            {
                checkForPlayer();
            }
        }
    }

    private void checkForPlayer()
    {
        calculateDirections();
        //check if spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if(hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void calculateDirections()
    {
        directions[0] = transform.right * range; //right
        directions[1] = -transform.right * range; //left
        directions[2] = transform.up * range; //up
        directions[3] = -transform.up * range; //down
    }

    private void spikeStop()
    {
        destination = transform.position;
        attacking = false;
    }

    private void OnTriggerEnter2Ds(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        //stop spikehead on hit
        spikeStop();
    }
}
