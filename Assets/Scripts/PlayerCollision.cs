using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float maxBounceAngle = 75f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallBehavior ball = collision.gameObject.GetComponent<BallBehavior>();

        if (ball != null)
        {
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / maxOffset) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
        }      
    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("powerup1")){
            GameEvents.current.PowerUp(1);
            Destroy(collider2D.gameObject);
        }
        else if(collider2D.CompareTag("powerup2")){
            GameEvents.current.PowerUp(2);
            Destroy(collider2D.gameObject);
        }
        else if(collider2D.CompareTag("powerup3")){
            GameEvents.current.PowerUp(3);
            Destroy(collider2D.gameObject);
        }
         else if(collider2D.CompareTag("powerup4")){
            GameEvents.current.PowerUp(4);
            Destroy(collider2D.gameObject);
        }
    }
}
