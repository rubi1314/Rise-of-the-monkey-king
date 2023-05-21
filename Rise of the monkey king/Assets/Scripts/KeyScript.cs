using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private bool isFollowing;
    public float followSpeed;
    public Transform followTarget;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == tag)
        {
            if (!isFollowing)
            {
                PlayerScript Player = FindObjectOfType<PlayerScript>();
                followTarget = Player.keyFollowPoint;
                isFollowing = true;
                Player.followingKey = this;
            }
        }
    }
}