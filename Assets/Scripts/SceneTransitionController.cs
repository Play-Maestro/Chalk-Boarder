using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    private Animator tranAnimator;
    private string nextSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        tranAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name, float waitTime = 0)
    {
        nextSceneName = name;
        Invoke("FadeOut", waitTime);
    }

    private void FadeOut()
    {
        tranAnimator.SetBool("FadeIn", false);
        Invoke("SceneChange", 1.3f);
    }

    private void SceneChange()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
