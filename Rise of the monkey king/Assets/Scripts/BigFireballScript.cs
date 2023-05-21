using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFireballScript : MonoBehaviour
{
    public float Speed;
    private Animator FireAnimator;
    private bool puedoseguir;
    private GameObject PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        FireAnimator = GetComponent<Animator>();
        FireAnimator.Play("GoFireball");
        if (transform.position.x < PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (transform.position.x > PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles == new Vector3(0, 0, 0))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed, Space.World);
        }

        if (transform.eulerAngles == new Vector3(0, 180, 0))
        {
            
            transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Suelo")
        {
            DestroyMe();
        }

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerScript>().TakeDamage();
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
