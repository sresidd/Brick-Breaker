using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    


    public GameObject pauseMenu;
    public  bool IsPaused;
    // Start is called before the first frame update

     
    void Start()
    {
     pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
          
           if(IsPaused)
           {
          
            ResumeGame();
           }
           else
           {
            PauseGame();
           }
        }
    }
    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame ();
        IsPaused=true;


    }
    public void ResumeGame(){
         pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused=false;

    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu");
        IsPaused = false;
    }

    public void quit(){
    Application.Quit();
   }

    
}
