using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text scoreText, mphText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScoreKeeper.lastScore.ToString() + "  FT";
        mphText.text = ScoreKeeper.fastestSpeed.ToString() + "  MPH";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
