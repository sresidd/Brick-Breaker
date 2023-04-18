using UnityEngine.SceneManagement;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{
   public void PlayGame(){
    SceneManager.LoadScene(1);
   }
   public void quit(){
    Application.Quit();
   }
    
}
