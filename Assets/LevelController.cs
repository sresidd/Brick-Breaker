using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private string levelIndex = "levelIndex";

    [SerializeField] private Button[] levels;

    void Start()
    {
        for(int i =0;i<levels.Length;i++){
            levels[i].interactable = false;
        }
        for(int i = 0;i<PlayerPrefs.GetInt(levelIndex,1);i++){
            levels[i].interactable = true;
        }

    }
}
