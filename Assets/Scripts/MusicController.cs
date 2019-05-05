using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip deadMusic;
    private AudioSource aSource;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeadMusic()
    {
        aSource.clip = deadMusic;
        aSource.Play();
        aSource.loop = false;
    }

    public void FadeOut()
    {
        anim.SetTrigger("Fade");
    }
}
