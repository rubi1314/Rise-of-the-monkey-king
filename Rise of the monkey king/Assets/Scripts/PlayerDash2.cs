using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;

    private float baseGrav;

    [SerializeField] private float dashingTime;
    [SerializeField] private float dashingCD;
    [SerializeField] private float dashForce;
    public bool isDashing;
    public bool canDash;
    public GameObject HyperJump;

    void Start()
    {
        dashingTime = 0.2f;
        dashingCD = 0.7f;
        dashForce = 35;
        canDash = true;
        isDashing = false;
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        
        baseGrav = rb.gravityScale;
    }


    void Update()
    {
        if (Input.GetButtonDown("Dash") && canDash == true && HyperJump.GetComponent<PlayerScript>().IsHyperjumping == false)
        {
            StartCoroutine(Dash());
        }

    }

    private IEnumerator Dash()
    {
        //Debug.Log("vas");
        isDashing = true;
        canDash = false;
        rb.gravityScale = 0;

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * dashForce, 0);
        }
        else
        {
            if (player.GetComponent<PlayerScript>().facinRight == true)
            {
                rb.velocity = new Vector2(1 * dashForce, 0);
            }
            else
            {
                rb.velocity = new Vector2(-1 * dashForce, 0);
            }
        }


        //Debug.Log("1");
        yield return new WaitForSeconds(dashingTime);
        //Debug.Log("2");
        isDashing = false;
        rb.gravityScale = 3.5f;
        //Debug.Log("3");
        yield return new WaitForSeconds(dashingCD);
        //Debug.Log("4");
        canDash = true;

    }
}