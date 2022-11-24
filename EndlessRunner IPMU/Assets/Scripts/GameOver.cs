using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    int yourScore;
    List<int> ranking;
    int aux;
    public Text rankingText;
    public Text yourScoreText;
    // Start is called before the first frame update
    void Awake()
    {
        aux = 1;
        yourScoreText.text = "holi uwu";
        yourScore = Between.score;
        ranking = Between.ranking;
        ranking.Sort();
        ranking.Reverse();
        foreach(int r in ranking){
            rankingText.text += aux.ToString() + "º: " + r.ToString() + " \n";
            aux++;
        }
        yourScoreText.text = "Tu puntuación: " + yourScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
