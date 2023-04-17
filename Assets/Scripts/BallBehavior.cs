
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class BallBehavior : MonoBehaviour
{

    public new Rigidbody2D rigidbody { get; private set; }
    public static Vector2 speed;
    public float currentSpeed;
    AudioSource Audio;

    [SerializeField] private enum DifficultyType{
        TimeBased,
        CollisionBased
    }

    [SerializeField] private float speedIncrementor = .1f;

    [SerializeField] private DifficultyType difficultyType;

    private bool canCollide = false;

    [SerializeField] GameObject impactParticle;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource> ();
        
    
    }

    private void Start()
    {
        // ResetBall();
        switch (difficultyType)
        {
            case DifficultyType.TimeBased:
                currentSpeed = speed.x;
                currentSpeed = Mathf.Lerp(speed.x, speed.y, Difficulty.GetDifficultyPercentage());
                break;
        }
        // currentSpeed = (speed.x + ((speed.y - speed.x) * Difficulty.GetDifficultyPercentage()));

        SetRandomTrajectory();
        GameEvents.current.OnColliderPowerUp += ColliderPowerUP;
        GameEvents.current.OnGameOver += Disable;
    }

    private void Disable()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
    }

    private void ColliderPowerUP(bool canCollide)
    {
        this.canCollide = canCollide;
    }

    public void ResetBall()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        
        rigidbody.AddForce(force.normalized * currentSpeed);
    }

    private void FixedUpdate()
    {
        switch (difficultyType)
        {
            case DifficultyType.TimeBased:
                currentSpeed = Mathf.Lerp(speed.x, speed.y, Difficulty.GetDifficultyPercentage());
                break;
        }
        rigidbody.velocity = rigidbody.velocity.normalized * currentSpeed;
    }

   void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.gameObject.CompareTag("platform")||collision2D.gameObject.CompareTag("breakable")){
            Instantiate(impactParticle,transform.position,Quaternion.identity);
              Audio.Play ();
        }
        if (collision2D.gameObject.CompareTag("breakable")){
            switch (difficultyType)
            {
                case DifficultyType.CollisionBased:
                    currentSpeed += speedIncrementor;
                    break;
            }

            Audio.Play ();
            GameEvents.current.BreakableCollision();
            int randchance = Random.Range (1, 11);
            if (randchance < 4)
            {
                GameEvents.current.BreakableColl(this.transform);
            }
        }
        if(collision2D.gameObject.CompareTag("lowercollider") && !canCollide){
            Audio.Play ();
            Destroy(this.gameObject);
            BallManager.ballCount--;
            if(BallManager.ballCount<1)SceneManager.LoadScene(0);
        }
    }

    private void OnDestroy(){
        GameEvents.current.OnColliderPowerUp -= ColliderPowerUP;
    }
}
 