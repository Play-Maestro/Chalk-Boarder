using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 targetPos = player.transform.position + Vector3.back * 10;
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.5f);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
