using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    [SerializeField] Button[] butonPause;
    [SerializeField] GameObject menuPause;

    public void pause()
    {
        
        Time.timeScale = 0f;
        foreach (Button b in butonPause)
        {
            b.enabled = false;
        }
        menuPause.SetActive(true);


    }

    public void Resume()
    {
        Time.timeScale = 1f;
        foreach (Button b in butonPause)
        {
            b.enabled = true;
        }
        menuPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Fire3"))
        {
            pause();
        }

    }
}
