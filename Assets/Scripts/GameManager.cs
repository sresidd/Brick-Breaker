using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform breakableParent;
    [SerializeField] private GameObject levelText;

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

    void Start()
    {
        scoreText.text = "score: "+ score;
        
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = highScore.ToString();

        GameEvents.current.OnBreakableCollision += IncrementScore;
        GameEvents.current.OnBreakableDestroyed += CheckBreakableCount;

        levelText.SetActive(true);
        Invoke(nameof(SetLevelTextInactive),1f);
    }

    private void SetLevelTextInactive()
    {
        levelText.SetActive(false);
    }

    private void CheckBreakableCount()
    {
        if(breakableParent.childCount < 2){
            PlayerPrefs.SetInt("levelIndex",SceneManager.GetActiveScene().buildIndex);
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
