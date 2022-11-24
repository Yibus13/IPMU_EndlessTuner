using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = FindObjectOfType<GameManager>().score;
    }
    private void OnDestroy()
    {
        Between.score = score;
        Between.ranking.Add(score);
    }
}