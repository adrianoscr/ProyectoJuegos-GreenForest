using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [Header("Move System")]
    [SerializeField]
    float speed = 6.0F;

    [SerializeField]
    bool isFacingRight = true;

    [SerializeField]
    bool wasFacingRight;

    Vector2 move;


    [Header("Jump System")]
    [SerializeField]
    float jumpPower = 2.0F;

    [SerializeField]
    LayerMask whatIsGround;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    float jumpTime = 0.75F;

    [SerializeField]
    float jumpMultiplier = 1.5F;

    [SerializeField]
    float fallMultiplier = 2.5F;

    bool isJumpPressed;
    float jumpCounter;

    Vector2 reverseGravity;


    [Header("Animation control")]
    [SerializeField]
    Animator animator;

    bool grounded;


    [Header("Particle System")]
    [SerializeField]
    ParticleSystem particle;



    void Start()
    {
        wasFacingRight = isFacingRight;
        reverseGravity = new Vector2(0.0F, -Physics2D.gravity.y);

        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        grounded = isGrounded();
    }


    /// <summary>
    /// Left or Right control
    /// </summary>
    void moving()
    {
        
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        flip();

    }


    /// <summary>
    /// Return true if is touching the floor.
    /// </summary>
    bool isGrounded()
    {

        return
            Physics2D.OverlapCapsule(
                    groundCheck.position,
                    new Vector2(1.48F, 0.29F),
                    CapsuleDirection2D.Horizontal,
                    0.0F,
                    whatIsGround
                );
    }


    /// <summary>
    /// Jumping control
    /// </summary>
    void jump()
    {
        //When it is jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpCounter = 0.0F;
                isJumpPressed = true;
            }
        }


        if (rb.velocity.y > 0.0F)
        {
            if (isJumpPressed)
            {

                rb.velocity += reverseGravity * jumpMultiplier * Time.deltaTime;

                jumpCounter += Time.deltaTime;

                if (jumpCounter > jumpTime)
                {
                    isJumpPressed = false;
                    jumpCounter = 0;

                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5F);
                }
            }

        }


        //It starts falling
        if (rb.velocity.y < 0.0F)
        {
            rb.velocity -= reverseGravity * fallMultiplier * Time.deltaTime;
        }


        //When it is falling
        if (Input.GetButtonUp("Jump"))
        {
            isJumpPressed = false;
            jumpCounter = 0.0F;

            //Reduce the jumping in 50%
            if (rb.velocity.y > 0.0F)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5F);
            }
        }



    }


    /// <summary>
    /// Flipping left of right
    /// </summary>
    void flip()
    {

        if (move.x != 0)
        {
            bool facingLeft = move.x < 0.0F;

            if (wasFacingRight != facingLeft)
            {
                wasFacingRight = facingLeft;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
        }

    }


    /// <summary>
    ///Animations controllers 
    /// </summary>
    void animations()
    {

        //Execute jump machine animation
        if (rb.velocity.y > 0.0F)
        {
            if (animator.GetFloat("power") != 1.0F)
            {
                animator.SetFloat("power", 1.0F);

            }
            grounded = false;
        }
        else if (rb.velocity.y < 0.0F)
        {
            if (animator.GetFloat("power") != -1.0F)
            {
                animator.SetFloat("power", -1.0F);

            }
            grounded = false;
        }
        //Execute walk animatione
        else if (animator.GetFloat("speed") != Mathf.Abs(move.x))
        {
            animator.ResetTrigger("grounded");
            animator.SetFloat("speed", Mathf.Abs(move.x));

        }

    }

    /// <summary>
    /// Player particles activation
    /// </summary>
    void activateParticles()
    {

        if (animator.GetFloat("speed") > 0.01F || animator.GetFloat("power") > 0.01F)
        {
            particle.Play();
        }
        else
        {
            particle.Stop();
        }

    }



    void Update()
    {
        //Getting left or right moving
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0.0F);

        jump();


        //If the player is not on the floor
        if (!grounded)
        {

            bool IsGrounded = isGrounded();

            if (grounded != IsGrounded)
            {
                grounded = IsGrounded;
                animator.SetFloat("power", 0.0F);
                animator.SetTrigger("grounded");
            }

        }


    }

    //It use physics, better move the player here.
    void FixedUpdate()
    {

        animations();

        activateParticles();

        moving();

    }






}
