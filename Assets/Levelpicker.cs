using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelpicker : MonoBehaviour
{
    public void LoadLevel(int sceneIndex)
    {
          SceneManager.LoadScene(sceneIndex);

    }
}
