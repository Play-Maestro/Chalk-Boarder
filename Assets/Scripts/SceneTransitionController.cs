using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    private Animator tranAnimator;
    private string nextSceneName;
    private bool transitioning = false;
    private MusicController music;
    private string thisScene;
    private AudioSource tranAudio;

    // Start is called before the first frame update
    void Start()
    {
        tranAnimator = GetComponent<Animator>();
        music = FindObjectOfType<MusicController>();
        thisScene = SceneManager.GetActiveScene().name;
        tranAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if((thisScene == "Scores" || thisScene == "Title") && !transitioning)
        {
            if (Input.GetButtonDown("Jump"))
            { 
                LoadScene("Game");
            }
        }
    }

    public void LoadScene(string name, float waitTime = 0)
    {
        transitioning = true;
        nextSceneName = name;
        Invoke("FadeOut", waitTime);
    }

    private void FadeOut()
    {
        tranAudio.Play();
        tranAnimator.SetBool("FadeIn", false);
        Invoke("SceneChange", 1.3f);
        music.FadeOut();
    }

    private void SceneChange()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
