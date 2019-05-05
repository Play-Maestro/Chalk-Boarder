using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitHead : MonoBehaviour
{
    public GameObject deadPrefab;
    public Transform snowBoard;
    private Rigidbody2D rb;
    private MusicController music;
    private SceneTransitionController sceneController;
    private ScoreText scoreText;

    private void Start()
    {
        rb = snowBoard.GetComponent<Rigidbody2D>();
        music = FindObjectOfType<MusicController>();
        sceneController = FindObjectOfType<SceneTransitionController>();
        scoreText = FindObjectOfType<ScoreText>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject dead = Instantiate(deadPrefab, snowBoard.position, snowBoard.rotation);
        dead.GetComponent<Rigidbody2D>().velocity = rb.velocity;
        dead.GetComponent<Rigidbody2D>().AddTorque(200, ForceMode2D.Impulse);
        music.DeadMusic();
        scoreText.SendScore();
        sceneController.LoadScene("Scores", 4);
        Destroy(snowBoard.gameObject);
    }
}
