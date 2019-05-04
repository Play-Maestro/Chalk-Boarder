using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSpawnLibrary : MonoBehaviour
{
    public GameObject[] snowRamps;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject randSnowRamp()
    {
        return snowRamps[Random.Range(0, snowRamps.Length)];
    }
}
