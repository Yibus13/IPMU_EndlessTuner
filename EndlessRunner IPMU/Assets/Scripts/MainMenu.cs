using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void LoadGame(){
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
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
