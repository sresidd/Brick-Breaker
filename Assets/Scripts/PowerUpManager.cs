using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private bool IsSlowedDown = false;

    private Coroutine c_timer; 

    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private float[] powerUpDuration;

    Coroutine C_ColliderPowerUp;
    Coroutine C_BoardPowerUp;

    void Start()
    {
        GameEvents.current.OnBreakableColl += InstantiatePowerUp;
        GameEvents.current.OnPowerUp += PowerUp;
    }

    private void PowerUp(int index)
    {
        switch(index){
            case 1:
            if(C_ColliderPowerUp != null) StopCoroutine(C_ColliderPowerUp);
            C_ColliderPowerUp = StartCoroutine(ColliderPowerUp());
            break;

            case 2:
            if(C_BoardPowerUp != null) StopCoroutine(C_BoardPowerUp);
            C_BoardPowerUp = StartCoroutine(BoardPowerUp());
            StartCoroutine(BoardPowerUp());
            break;

            case 3:
            GameEvents.current.BallPowerUp();
            break;
        }
    }

    private void InstantiatePowerUp(Transform objTransform)
    {
        int randomPowerUP = UnityEngine.Random.Range(0,powerUps.Length);
        Instantiate(powerUps[randomPowerUP], objTransform.position, Quaternion.identity);
    }

    private IEnumerator ColliderPowerUp(){
        GameEvents.current.ColliderPowerUp(true);
        yield return new WaitForSeconds(powerUpDuration[0]);
        GameEvents.current.ColliderPowerUp(false);
    }

    private IEnumerator BoardPowerUp(){
        GameEvents.current.BoardPowerUp(true);
        yield return new WaitForSeconds(powerUpDuration[1]);
        GameEvents.current.BoardPowerUp(false);
    }

    private void OnDisable(){
        GameEvents.current.OnBreakableColl -= InstantiatePowerUp;
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
