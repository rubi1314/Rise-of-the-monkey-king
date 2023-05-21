using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    private PlayerScript Player;
    public Transform Key;
    static public bool open = false;
    private GameObject PressE;

    // Start is called before the first frame update
    void Start()
    {
        //PressE = GameObject.Find("PuertaE").GetComponent<SpriteRenderer>();
        Player = FindObjectOfType<PlayerScript>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Player.followingKey != null)
            {
                Player.followingKey.followTarget = Key.transform;
                open = true;
                //PressE = GetComponent<SpriteRenderer>(enabled);


            }
        }
        
    }
    
}
