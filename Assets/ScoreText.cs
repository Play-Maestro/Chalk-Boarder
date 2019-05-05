using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Transform player;
    public Text mphText;

    private Text scoreText;
    private int score = 0;
    private int mph = 0;
    private int topSpeed = 0;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if ((int)(player.position.x * 5) > score)
            {
                score = (int)(player.position.x * 4);
            }
        }

        scoreText.text = score.ToString() + "  ft";

        if (rb != null)
        {
            mph = (int)(rb.velocity.magnitude * 2.462);
        }
        else
        {
            mph = 0;
        }
        mphText.text = mph.ToString() + "  mph";
        if(topSpeed < mph)
        {
            topSpeed = mph;
        }
        print(topSpeed);
    }

    public void SendScore()
    {
        ScoreKeeper.AddScore(score);
        ScoreKeeper.SetFastestSpeed(topSpeed);
    }
}
