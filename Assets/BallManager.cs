using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private BallBehavior ball;
    public static int ballCount = 1;
    void Start()
    {
        GameEvents.current.OnBallPowerUp += AddBall;
    }

    private void AddBall()
    {
        Instantiate(ball, Vector2.zero, Quaternion.identity);
        ballCount++;
    }
}
