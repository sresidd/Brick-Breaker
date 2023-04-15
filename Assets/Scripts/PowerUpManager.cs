using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

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
}
