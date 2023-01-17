using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void playGame()
    {

        StartCoroutine(LoadGame());
        Time.timeScale = 1f;
    }

    IEnumerator LoadGame()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("GameScene");
    }
    /*
        public void LoadTutorial(){
            SceneManager.LoadScene("Tutorial");
        }

        public void LoadMenu(){
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadCredits(){
            SceneManager.LoadScene("Credits");
        }
        */

    public void playScene(string name)
    {

        StartCoroutine(LoadScene(name));
        Time.timeScale = 1f;
    }
    IEnumerator LoadScene(string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(name);
    }
}
