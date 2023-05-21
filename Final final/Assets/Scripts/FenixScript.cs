using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenixScript : MonoBehaviour
{
    public int vida;
    private GameObject PlayerObj;
    private Animator EnemyAnim;
    private Rigidbody2D myrigi;
    public GameObject Fireball;
    private bool fenixAttacking = false;
    private float timeLeft = 3;
    private bool Feedback = false;
    private bool IsAttacking = false;

    private bool golpe = false;
    public float fuerza;

    

    // Start is called before the first frame update
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();

        PlayerObj = GameObject.Find("Player");

        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Feedback == false && IsAttacking == false)
        {
            EnemyAnim.Play("Fenix_Idle");
        }

        if (transform.position.x < PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (transform.position.x > PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft <=0)
        {
            timeLeft = 3;
            EnemyAnim.Play("Fenix_Attack");
        }
      
    }

    private void SpawnFireball()
    {
        Instantiate(Fireball, transform.position + new Vector3(0f, 0.9f, 0), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hit")
        {
            EnemyAnim.Play("Fenix_Hit");
            vida--;
            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }          
        }

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerScript>().TakeDamage();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hit")
        {
            golpe = false;
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

    public void IsAttackingToTrue()
    {
        IsAttacking = true;
    }

    public void IsAttackingToFalse()
    {
        IsAttacking = false;
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}

