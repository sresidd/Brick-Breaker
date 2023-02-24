using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public int score;
    public TMP_Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "score: "+ score;
        BallBehavior.OnBreakbleCollision += UpdateScore;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore()
    {
        score ++;
        scoreText.text = "score: "+ score;
    }
}
