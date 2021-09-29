using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCoolDown;
    private float horizontalInput;
    private float trX, trY;

    private void Awake()
    {
        //reference for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        trX = transform.localScale.x;
        trY = transform.localScale.y;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        //flip player when player move right and left
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(trX, trY, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-trX, trY, 1);
        }

        //set animator paramater
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //walljump logic
        if(wallJumpCoolDown < 0.2f)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 3;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                jump();
            }
        }
        else
        {
            wallJumpCoolDown += Time.deltaTime;
        }
    }

    private void jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if(onWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }

            wallJumpCoolDown = 0;
        }   
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    public bool fireSkillUnlocked()
    {
        //string currentScene = SceneManager.GetActiveScene().name;
        //if (currentScene == "Stage_01"
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex > 0) //change this later
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}