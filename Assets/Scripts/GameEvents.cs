using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake(){
        current = this;
    }

    //Events
    public event Action<bool> OnColliderPowerUp;
    public event Action<bool> OnBoardPowerUp;
    public event Action<int> OnPowerUp;
    public event Action OnBreakableCollision; 
    public event Action<Transform> OnBreakableColl;
    public event Action OnBallPowerUp;
    public event Action OnBreakableDestroyed;
    public event Action OnGameOver;
    public event Action OnCameraShake;

    //Methods
    public void ColliderPowerUp(bool isCollided) => OnColliderPowerUp?.Invoke(isCollided);
    public void BoardPowerUp(bool isCollided) => OnBoardPowerUp?.Invoke(isCollided);
    public void PowerUp(int powerUpInt) => OnPowerUp?.Invoke(powerUpInt);
    public void BreakableCollision() => OnBreakableCollision?.Invoke();
    public void BreakableColl(Transform obj) => OnBreakableColl?.Invoke(obj);
    public void BallPowerUp() => OnBallPowerUp?.Invoke();
    public void BreakableDestroyed() => OnBreakableDestroyed?.Invoke();
    public void GameOver() => OnGameOver?.Invoke();
    public void CameraShake() => OnCameraShake?.Invoke();
}
