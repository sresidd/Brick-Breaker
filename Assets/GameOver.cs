using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class GameOver : MonoBehaviour
{
    private bool hasCollided = false;
    private AudioSource audioSource;
    [SerializeField] private GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasCollided = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("lowercollider") && !hasCollided)
        {
            audioSource?.Play();
            Destroy(gameObject);
            BallManager.ballCount--;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Levels(){
    SceneManager.LoadScene(1);
   }
    public void Retry()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0");
    }
}