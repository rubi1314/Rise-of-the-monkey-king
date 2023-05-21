using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortugaScript : MonoBehaviour
{
    public int vida = 3;
    private GameObject PlayerObj;
    private Animator EnemyAnim;
    private Rigidbody2D myrigi;
    public float speed = 3;
    private bool _switch = false;
    private bool Feedback = false;



    // Start is called before the first frame update
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Feedback == false)
        {
            EnemyAnim.Play("Tortuga_Idle");
        }
        
        if (_switch == false)
        {
            myrigi.velocity = new Vector2(-speed, myrigi.velocity.y);
        }

        if (_switch == true)
        {
            myrigi.velocity = new Vector2(speed, myrigi.velocity.y);
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hit")
        {
            EnemyAnim.Play("Tortuga_Hit");
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

        if (col.gameObject.tag == "1")
        {
            _switch = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (col.gameObject.tag == "2")
        {
            _switch = true;
            transform.eulerAngles = new Vector3(0, 180, 0);
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


