using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastonScript : MonoBehaviour
{
    public GameObject Pared;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(Pared);
        }
        
        
    }
}
