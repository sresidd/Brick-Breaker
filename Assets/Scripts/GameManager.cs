
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
     public TMP_Text highScoreText;

    int highScore;
    public int score;
    public TMP_Text scoreText;

    string highScoreKey = "HighScore";

          private void IncrementScore()
    {
        score++;
        scoreText.text = scoreText.ToString();



    }



    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "score: "+ score;
        // BallBehavior.OnBreakbleCollision += UpdateScore;
        GameEvents.current.OnBreakableCollision += IncrementScore;
         highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = highScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();
        }
    }
    public void UpdateScore()
    {
        score ++;
        scoreText.text = "score: "+ score;
    }
}
