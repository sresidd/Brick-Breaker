using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform breakableParent;

    private int highScore;
    public int score;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private string highScoreKey = "HighScore";

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
        
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = highScore.ToString();

        GameEvents.current.OnBreakableCollision += IncrementScore;
        GameEvents.current.OnBreakableDestroyed += CheckBreakableCount;
    }

    private void CheckBreakableCount()
    {
        if(breakableParent.childCount < 2){
            GameEvents.current.GameOver();
        }
    }

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

    public void Restart()
    {
        SceneManager.LoadScene(GetBuildIndex());
    }

    public void Next(){
        SceneManager.LoadScene(GetBuildIndex() + 1);
    }

    private int GetBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
