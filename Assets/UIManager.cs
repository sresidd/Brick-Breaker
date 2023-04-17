using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameWinImg;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnGameOver += GameOver;
    }

    private void GameOver()
    {
        gameWinImg.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
