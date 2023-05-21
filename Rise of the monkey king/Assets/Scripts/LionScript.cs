using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript : MonoBehaviour
{
    public int vida;
    public int Speed;
    private Animator LionAnim;
    private Rigidbody2D LionRigi;
    private bool LionIsAttacking = false;
    public GameObject PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        LionRigi = GetComponent<Rigidbody2D>();
        LionAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LionIsAttacking == false)
        {
            LionAnim.Play("Lion_Idle");
            //LionRigi.velocity = new Vector2(0, LionRigi.velocity.y);
        }
    }

    public void LeonMenosVida()
    {
        vida--;
        LionAnim.Play("Lion_Hit");
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }      
    }

    public void LionAttack()
    {
        LionAnim.Play("Lion_Attack");

        if (transform.position.x < PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (transform.position.x > PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }        

        if (transform.eulerAngles.y == 0)
        {
            LionRigi.velocity = new Vector2(-Speed, LionRigi.velocity.y);
        }

        if (transform.eulerAngles.y == 180)
        {
            LionRigi.velocity = new Vector2(Speed, LionRigi.velocity.y);
        }
    }

    public void TrueAttt()
    {
        LionIsAttacking = true;
    }

    public void FalseAttt()
    {
        LionIsAttacking = false;
    }
}
