using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    public float Jump;
    public float HyperJump;
    private Animator Myanimator;
    private SpriteRenderer Mysprite;
    private bool IsAttacking = false;
    private bool IsDead = false;
    private Rigidbody2D myrigi;
    private bool IsJumping = false;
    static public int vidas = 6;
    private float timeLeft = 3;
    public bool IsHyperjumping = false;
    private bool Feedback = false;

    public bool facinRight;

    public Transform keyFollowPoint;
    public KeyScript followingKey;

    public GameObject dash;

    public CameraScript cameraShake;

    private float baseGrav;
    private float dashingTime = 0.3f;
    private float dashingCooldown = 0.5f;
    private float dashForce = 20;
    public bool isDashing = false;
    public bool canDash = true;
    public bool tengoBaston = false;
    public bool isFalling = false;


    void Start()
    {
        Myanimator = GetComponent<Animator>();
        Mysprite = GetComponent<SpriteRenderer>();
        myrigi = GetComponent<Rigidbody2D>();       
    }

    
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Boss")
        {
            DialogueScript.canSkill = true;
        }

        if(dash.GetComponent<PlayerDash2>().isDashing == false && IsDead == false && Feedback == false)
        {
            if (tengoBaston == false)
            {
                if (Input.GetAxisRaw("Horizontal") == 0 && IsAttacking == false && IsJumping == false)
                {
                    myrigi.velocity = new Vector2(0, myrigi.velocity.y);
                    Myanimator.Play("Player_Idle");
                }

                if (Input.GetAxisRaw("Horizontal") > 0 && IsAttacking == false)
                {
                    myrigi.velocity = new Vector2(Speed, myrigi.velocity.y);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    facinRight = true;
                    IsAttacking = false;
                    if (IsJumping == false)
                    {
                        Myanimator.Play("Player_Run");
                    }
                }

                if (Input.GetAxisRaw("Horizontal") < 0 && IsAttacking == false)
                {
                    myrigi.velocity = new Vector2(-Speed, myrigi.velocity.y);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    facinRight = false;
                    IsAttacking = false;
                    if (IsJumping == false)
                    {
                        Myanimator.Play("Player_Run");
                    }
                }

                if (Input.GetButtonDown("Jump") && transform.Find("GroundCheck").GetComponent<GroundCheckScript>().tocosuelo)
                {
                    Myanimator.Play("Player_Jump");

                    ApplyJump();
                }
            }

            if (tengoBaston == true)
            {
                if (Input.GetAxisRaw("Horizontal") == 0 && IsAttacking == false && IsJumping == false && IsHyperjumping == false)
                {
                    myrigi.velocity = new Vector2(0, myrigi.velocity.y);
                    Myanimator.Play("Player_Idle_Baston");
                }

                if (Input.GetAxisRaw("Horizontal") > 0 && IsAttacking == false && IsHyperjumping == false)
                {
                    myrigi.velocity = new Vector2(Speed, myrigi.velocity.y);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    facinRight = true;
                    IsAttacking = false;
                    if (IsJumping == false)
                    {
                        Myanimator.Play("Player_Run_Baston");
                    }
                }

                if (Input.GetAxisRaw("Horizontal") < 0 && IsAttacking == false && IsHyperjumping == false)
                {
                    myrigi.velocity = new Vector2(-Speed, myrigi.velocity.y);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    facinRight = false;
                    IsAttacking = false;
                    if (IsJumping == false)
                    {
                        Myanimator.Play("Player_Run_Baston");
                    }
                }

                if (Input.GetKeyDown(KeyCode.J) && IsHyperjumping == false)
                {
                    myrigi.velocity = new Vector2(0, myrigi.velocity.y);
                    Myanimator.Play("Player_Fight");
                    //StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
                }

                if (Input.GetButtonDown("Jump") && transform.Find("GroundCheck").GetComponent<GroundCheckScript>().tocosuelo)
                {
                    Myanimator.Play("Player_Jump_Baston");

                    ApplyJump();
                }                
            }

            if (DialogueScript.canSkill == true)
            {
                if (Input.GetKeyDown(KeyCode.K) && transform.Find("GroundCheck").GetComponent<GroundCheckScript>().tocosuelo)
                {
                    myrigi.velocity = new Vector2(0, myrigi.velocity.y);
                    Myanimator.Play("Player_Hyperjump");
                }
            }
           


        }




    }


    public void IsFallingToTrue()
    {
        isFalling = true;
    }
    public void IsFallingToFalse()
    {
        isFalling = false;        
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

    public void IsDeadToTrue()
    {
        IsDead = true;
    }

    public void IsDeadToFalse()
    {
        IsDead = false;
    }

    public void TrueHyperjumping()
    {
        IsHyperjumping = true;
    }

    public void FlaseHyperjumping()
    {
        IsHyperjumping = false;
    }

    public void TrueBaston()
    {
        tengoBaston = true;
    }


    public void ApplyJump()
    {
        myrigi.velocity = new Vector2(myrigi.velocity.x, Jump);
    }

    public void ApplyHyperJump()
    {
        myrigi.velocity = new Vector2(myrigi.velocity.x, HyperJump);
    }

    public void TakeDamage()
    {
        if (tengoBaston == false && IsDead == false)
        {
            Myanimator.Play("Player_Hit");
        }

        else if (tengoBaston == true && IsDead == false)
        {
            Myanimator.Play("Player_Baston_Hit");
        }

        vidas--;
        Debug.Log(vidas);
        if (vidas <= 0)
        {
            myrigi.velocity = new Vector2(0, myrigi.velocity.y);
            IsDead = true;
            IsAttacking = false;
            IsJumping = false;
            Myanimator.Play("Player_Death");            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Baston")
        {
            tengoBaston = true;
        }


    }

    public void TrueFeedBack()
    {
        Feedback = true;
    }

    public void FalseFeedBack()
    {
        Feedback = false;
    }
}
