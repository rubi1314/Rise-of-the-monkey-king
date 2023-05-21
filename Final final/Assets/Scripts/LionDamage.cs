using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hit")
        {
            GameObject.Find("FuLion").GetComponent<LionScript>().LeonMenosVida();
        }

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerScript>().TakeDamage();
        }
    }
}
