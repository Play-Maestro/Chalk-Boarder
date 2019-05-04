using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowRamp : MonoBehaviour
{
    public Transform spawnPoint;

    private Vector3 spawnPosition;
    private Transform player;
    private SnowSpawnLibrary snowLib;
    private bool nextSpawn = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerSnowController>().transform;
        snowLib = FindObjectOfType<SnowSpawnLibrary>();
    }


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (!nextSpawn)
            {
                if (Vector3.Distance(player.position, transform.position) < 20)
                {
                    print("Spawn");
                    Instantiate(snowLib.randSnowRamp(), spawnPosition, Quaternion.identity);
                    nextSpawn = true;
                }
            }
            else
            {
                if (Vector3.Distance(player.position, transform.position) > 30)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
