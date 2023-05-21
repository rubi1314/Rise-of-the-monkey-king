using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private float horizontal;
    private float speed = 6;
    private float jumpingPower = 16;
    private bool isFacingRight = true;
    private bool canDash = true;
    public bool isDashing;
    private float dashingPower = 24;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    static public int vidas = 6;
    private bool IsAttacking = false;
    private bool IsJumping = false;
    private Animator Myanimator;
    private SpriteRenderer Mysprite;



    void Start()
    {
        Myanimator = GetComponent<Animator>();
        Mysprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }


        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Myanimator.Play("Player_Jump_Baston");
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            Myanimator.Play("Player_Jump_Baston");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        

        /*if (horizontal == 0 && IsAttacking == false && IsJumping == false)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            Myanimator.Play("Player_Idle_Baston");

            if (Input.GetButtonDown("Fire1"))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                Myanimator.Play("Player_Fight");
            }
        }

        if (horizontal > 0 && IsAttacking == false && IsJumping == false)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 0);
            Myanimator.Play("Player_Run_Baston");

            if (Input.GetButtonDown("Fire1"))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                Myanimator.Play("Player_Fight");
            }
        }

        if (horizontal < 0 && IsAttacking == false && IsJumping == false)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0);
            Myanimator.Play("Player_Run_Baston");

            if (Input.GetButtonDown("Fire1"))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                Myanimator.Play("Player_Fight");
            }
        }*/

        Flip();
    }

    public void IsAttackingToTrue()
    {
        IsAttacking = true;
    }

    public void IsAttackingToFalse()
    {
        IsAttacking = false;
    }
    public void IsJumpingToTrue()
    {
        IsJumping = true;
    }
    public void IsJumpingToFalse()
    {
        IsJumping = false;
    }

    public void TakeDamage()
    {
        vidas--;
        if (vidas <= 0)
        {
            IsAttacking = false;
            IsJumping = false;
            //Myanimator.Play("PlayerDie");
        }
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        

        if (horizontal == 0 && IsAttacking == false && IsJumping == false)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            Myanimator.Play("Player_Idle_Baston");
        }
        else
        {
            Myanimator.Play("Player_Run_Baston");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            Myanimator.Play("Player_Fight");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1;
            transform.localScale = localScale;
        } 
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
