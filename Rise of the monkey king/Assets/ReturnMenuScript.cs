using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMenu()
    {
        GameObject.Find("UIManager").GetComponent<UIManagerScript>().ReturnMenu();
    }
}
