using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int vida;
    private bool PuedoCaminar = true;
    public float Speed;
    private GameObject PlayerObj;
    private Animator EnemyAnim;
    private Rigidbody2D myrigi;

    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();

        PlayerObj = GameObject.Find("Player");

        EnemyAnim = GetComponent<Animator>();

        if (transform.position.x < PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (transform.position.x > PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PuedoCaminar == true)

        {
            if (transform.eulerAngles.y == 0)
            {
                myrigi.velocity = new Vector2(-Speed, myrigi.velocity.y);
            }

            if (transform.eulerAngles.y == 180)
            {
                myrigi.velocity = new Vector2(Speed, myrigi.velocity.y);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.gameObject.tag == "Hit")
        {
            vida--;

            if (vida <= 0)
            {
                //EnemyAnim.Play("EnemyDie");
                PuedoCaminar = false;
                myrigi.velocity = Vector2.zero;
                Destroy(this.gameObject);
            }
        }

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerScript>().TakeDamage();

        }
    }
    public void PuedoCaminarATrue()
    {
        PuedoCaminar = true;
    }


    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    public void PuedoCaminarAFalse()
    {
        PuedoCaminar = false;
        EnemyAnim.Play("Enemy_Die");
    }
}
