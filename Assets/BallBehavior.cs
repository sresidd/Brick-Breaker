using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class BallBehavior : MonoBehaviour
{
    public static event System.Action OnBreakbleCollision; 
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 10f;

    [SerializeField] GameObject impactParticle;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // ResetBall();
        SetRandomTrajectory();
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

        rigidbody.AddForce(force.normalized * speed);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
    }

   void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.gameObject.CompareTag("platform")||collision2D.gameObject.CompareTag("breakable")){
            Instantiate(impactParticle,transform.position,Quaternion.identity);
        }
        if (collision2D.gameObject.CompareTag("breakable")){
            OnBreakbleCollision?.Invoke();
        }
        if(collision2D.gameObject.CompareTag("lowercollider")){
            SceneManager.LoadScene(0);
        }
    }
}
 