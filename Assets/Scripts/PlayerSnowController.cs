using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnowController : MonoBehaviour
{
    public Sprite normalDude, crouchDude;
    public SpriteRenderer dudeRenderer;
    public GroundSense groundSense;
    public ParticleSystem snowSystem;
    public ParticleSystem hitSnow;
    public AudioSource jumpSound, landSound;

    private float originalGrav = 0.3f, fastGrav = 0.5f;
    private bool isCrouched = false;
    private bool jumping = false;
    private Rigidbody2D rb;
    private float jumpForce = 0;
    private AudioSource boardingSFX;
    private float sfxVolume = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = originalGrav;
        boardingSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            rb.gravityScale = fastGrav;
            jumpForce = Mathf.Clamp(jumpForce + Time.deltaTime, 0, 3);
            dudeRenderer.sprite = crouchDude;
            rb.AddTorque(-12);
        }
        else
        {
            rb.AddTorque(8);
        }
        if (Input.GetButtonUp("Jump"))
        {
            rb.gravityScale = originalGrav;
            if (groundSense.OnGround()) {
                rb.AddForce((transform.up * jumpForce + transform.right) * rb.mass * 1.1f, ForceMode2D.Impulse);
                jumpSound.pitch = Random.Range(0.5f, 1.2f);
                jumpSound.Play();
            }
            jumpForce = 0;
            dudeRenderer.sprite = normalDude;
        }

        if (groundSense.OnGround() && rb.velocity.magnitude > 2)
        {
            snowSystem.enableEmission = true;
            sfxVolume = Mathf.Clamp(sfxVolume + Time.deltaTime, 0, 0.7f);
        }
        else
        {
            snowSystem.enableEmission = false;
            sfxVolume = Mathf.Clamp(sfxVolume - Time.deltaTime * 10, 0, 0.7f);
        }

        if(jumping && groundSense.OnGround())
        {
            jumping = false;
            hitSnow.Play();
            landSound.pitch = Random.Range(0.5f, 1.2f);
            landSound.Play();
        }
        if(!jumping && groundSense.OnGround() == false)
        {
            jumping = true;
        }

        boardingSFX.volume = sfxVolume;
        
    }
}
