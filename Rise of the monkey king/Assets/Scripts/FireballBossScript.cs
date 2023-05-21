using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBossScript : MonoBehaviour
{
    public float Speed;
    private Animator FireAnimator;
    private bool puedoseguir;
    private GameObject PlayerObj;

    void Start()
    {

        FireAnimator = GetComponent<Animator>();
        puedoseguir = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (puedoseguir == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.Self);
            transform.eulerAngles = new Vector3(0, 0, 90);
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

        if (col.gameObject.tag == "Suelo")
        {
            DestroyMe();
        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
