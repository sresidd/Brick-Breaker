using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class BreakableBehavior : MonoBehaviour

{
    
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states = new Sprite[0];
    public int health { get; private set; }
    public int points = 1;
    public bool unbreakable;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Start()
    {{
        ResetBrick();
    }

     void ResetBrick()
    {
        gameObject.SetActive(true);

        if (!unbreakable)
        {
           
            health = states.Length;
            spriteRenderer.sprite = states[health - 1];
        }
    }

    }

   

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("ball")||!unbreakable)
        
        {
          health --;
          if (health<1) Destroy(this.gameObject);
          else
          {
            spriteRenderer.sprite= states [health - 1];         
          }
        }
    }
}
