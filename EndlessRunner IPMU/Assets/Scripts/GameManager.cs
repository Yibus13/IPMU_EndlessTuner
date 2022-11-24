using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public TextMeshProUGUI scoreText;
    public PlayerMovement playerMovement;

    public void AddScore(){
        score++;
        scoreText.text = "Score: " + score;
        playerMovement.speed += playerMovement.acceleration;
    }
    public static GameManager inst;
    void Awake()
    {
        inst = this;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
