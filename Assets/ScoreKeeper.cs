using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper
{
    public static List<int> scores = new List<int>();
    public static int lastScore;
    public static int fastestSpeed;

    public static void AddScore(int score)
    {
        lastScore = score;
        scores.Add(score);
        scores.Sort();
    }

    public static void SetFastestSpeed(int speed)
    {
        fastestSpeed = speed;
    }
}
