using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float Speed;
    private Animator FireAnimator;
    private bool puedoseguir;
    private GameObject PlayerObj;

    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        FireAnimator = GetComponent<Animator>();
        puedoseguir = true;

        if (puedoseguir == true && transform.position.x < PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (puedoseguir == true && transform.position.x > PlayerObj.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles == new Vector3(0, 180, 0))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.Self);
        }

        if (transform.eulerAngles == new Vector3(0, 0, 0))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.Self);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Fenix" && col.gameObject.tag != "Hit")
        {
            puedoseguir = false;
            DestroyMe();
        }

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerScript>().TakeDamage();

        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
