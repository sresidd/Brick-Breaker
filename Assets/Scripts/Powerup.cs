using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed;

    void Update()
    {
      transform.Translate (new Vector2 (0f, -1f* Time.deltaTime * speed));

      if (transform.position.y < -6f)
      {
        Destroy (gameObject);
      }
    }
}
