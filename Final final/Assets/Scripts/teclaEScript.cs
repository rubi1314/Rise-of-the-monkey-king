using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teclaEScript : MonoBehaviour
{
    static public bool Habilidad = false;
    static public bool dialogo = false;
    // Start is called before the first frame update
    void Start()
    {
        Habilidad = false; 
        dialogo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Habilidad = true;
            dialogo = true;
        }
    }
}

