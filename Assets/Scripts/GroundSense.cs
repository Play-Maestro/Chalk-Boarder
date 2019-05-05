using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSense : MonoBehaviour
{
    private float groundedTimer = 0.8f;

    private void Update()
    {
        if(groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            groundedTimer = Time.deltaTime * 3;
        }
    }


    public bool OnGround()
    {
        return (groundedTimer > 0);
    }
}
