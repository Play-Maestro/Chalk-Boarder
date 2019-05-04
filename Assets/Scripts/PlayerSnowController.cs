using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnowController : MonoBehaviour
{
    public Sprite normalDude, crouchDude;
    public SpriteRenderer dudeRenderer;

    private float originalGrav = 0.3f, fastGrav = 0.5f;
    private bool isCrouched = false;
    private bool jumping = false;
    private Rigidbody2D rb;
    private float jumpForce = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = originalGrav;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            rb.gravityScale = fastGrav;
            jumpForce = Mathf.Clamp(jumpForce + Time.deltaTime, 0, 3);
            dudeRenderer.sprite = crouchDude;
            rb.drag = 0;
            rb.AddTorque(-12);
            print("Crouch");
        }
        else
        {
            rb.drag = 0.1f;
            rb.AddTorque(8);
        }
        if (Input.GetButtonUp("Jump"))
        {
            rb.gravityScale = originalGrav;
            rb.AddForce((transform.up * jumpForce + transform.right)*rb.mass*1.1f, ForceMode2D.Impulse);
            jumpForce = 0;
            dudeRenderer.sprite = normalDude;
            print("Jump");
        }
    }
}
