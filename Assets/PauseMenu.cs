using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    private bool IsPaused = false;
    private bool IsSlowedDown = false;

    private Coroutine c_timer; 
     
    void Start() => pauseMenu.SetActive(false);

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) SlowDow();
        if(!Input.GetKeyDown(KeyCode.Escape)) return;
        if(IsPaused) ResumeGame();
        else if(!IsPaused) PauseGame();
    }

    public void PauseGame(){
        IsPaused=true;
        UpdateTimeScale(0f);
        pauseMenu.SetActive(true);
    }

    public void ResumeGame(){
        IsPaused=false;
        if(c_timer != null) StopCoroutine(c_timer);
        c_timer = StartCoroutine(ScaleTime(0f,1f,2f));

        pauseMenu.SetActive(false);

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
        IsPaused = false;
    }

    public void SlowDow(){
        if(IsSlowedDown)
        {
            IsSlowedDown = false;
            if(c_timer != null)StopCoroutine(c_timer);
            c_timer = StartCoroutine(ScaleTime(.2f, 1f, 3f));
        }

        else if(!IsSlowedDown)
        {
            IsSlowedDown = true;
            if(c_timer != null)StopCoroutine(c_timer);
            c_timer = StartCoroutine(ScaleTime(1f, .2f, 3f));
        }
    }

    public static IEnumerator ScaleTime(float start, float end, float time)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }
        Time.timeScale = end;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void UpdateTimeScale(float timeScale){
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void quit() => Application.Quit();
    
}
