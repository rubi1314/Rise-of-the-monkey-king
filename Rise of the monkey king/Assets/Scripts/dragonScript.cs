using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonScript : MonoBehaviour
{
    private Animator Myanimator;
    private SpriteRenderer Mysprite;
    private Rigidbody2D myrigi;
    static public int vidas = 30;
    private float timeLeft = 8;
    private float timeLeft2 = 8;
    private float timeLeft3 = 12;
    public GameObject Fireball;
    public GameObject BigFireball;
    private bool IsAttacking = false;
    private bool Feedback = false;
    private bool IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerScript>().TrueBaston();
        Myanimator = GetComponent<Animator>();
        Mysprite = GetComponent<SpriteRenderer>();
        myrigi = GetComponent<Rigidbody2D>();
        Myanimator.Play("Dragon_Idle");
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeft2 -= Time.deltaTime;
        timeLeft3 -= Time.deltaTime;

        if (IsDead == false)
        {
            if (timeLeft <= 4)
            {
                Myanimator.Play("Dragon_Attack");
                timeLeft = 1000000;

            }

            if (timeLeft3 <= 0)
            {
                timeLeft3 = 8;
                Myanimator.Play("Dragon_Attack");
            }

            if (timeLeft2 <= 0)
            {
                timeLeft2 = 8;
                Myanimator.Play("Dragon_Attack_2");
            }

            if (IsAttacking == false && Feedback == false)
            {
                Myanimator.Play("Dragon_Idle");
            }
        }

        if (vidas <= 0)
        {
            Myanimator.Play("Dragon_Die");
        }
    }
    private void SpawnFireball()
    {
        Instantiate(Fireball, transform.position + new Vector3(-9f, 5f, 0), Quaternion.identity);
        Instantiate(Fireball, transform.position + new Vector3(-6f, 5f, 0), Quaternion.identity);
        Instantiate(Fireball, transform.position + new Vector3(-3f, 5f, 0), Quaternion.identity);
        Instantiate(Fireball, transform.position + new Vector3(0f, 5f, 0), Quaternion.identity);
        Instantiate(Fireball, transform.position + new Vector3(3f, 5f, 0), Quaternion.identity);
        Instantiate(Fireball, transform.position + new Vector3(6f, 5f, 0), Quaternion.identity);
        Instantiate(Fireball, transform.position + new Vector3(9f, 5f, 0), Quaternion.identity);
    }

    private void SpawnBigFireball()
    {
        Instantiate(BigFireball, transform.position + new Vector3(-12f, -3f, 0), Quaternion.identity);
        Instantiate(BigFireball, transform.position + new Vector3(12f, 3f, 0), Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hit" && IsDead == false)
        {
            Myanimator.Play("Dragon_Hit");
            vidas--;            
        }
    }
    public void IsAttackingToTrue()
    {
        IsAttacking = true;
    }

    public void IsAttackingToFalse()
    {
        IsAttacking = false;
    }

    public void TrueFeedBack()
    {
        Feedback = true;
    }

    public void FalseFeedBack()
    {
        Feedback = false;
    }

    public void TrueDead()
    {
        IsDead = true;
    }

 
}
