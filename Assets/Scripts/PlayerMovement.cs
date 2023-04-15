using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;

    private bool changeBoard = false;


    [SerializeField] private float lerpSpeed = 2f;
    private float lerpTime = 0f;

    private Vector2 finalScale;
    private Vector2 initialScale;

    [SerializeField] private float XScale = 5f;

    [SerializeField] private float xoffset;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPaddle();
        GameEvents.current.OnBoardPowerUp += ChangeBoard;
        finalScale = new Vector2(XScale,transform.localScale.y);
        initialScale = transform.localScale;
    }

    private void ChangeBoard(bool changeBoard)
    {
        this.changeBoard = changeBoard;
    }

    public void ResetPaddle()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = new Vector2(0f, transform.position.y);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            direction = Vector2.right;
        } else {
            direction = Vector2.zero;
        }

        if(transform.position.x >= ScreenSize.ReturnHalfScreenWidth() - xoffset)transform.position = new Vector2(ScreenSize.ReturnHalfScreenWidth() - xoffset,transform.position.y);
        else if(transform.position.x<= -ScreenSize.ReturnHalfScreenWidth() + xoffset)transform.position = new Vector2(-ScreenSize.ReturnHalfScreenWidth() + xoffset,transform.position.y);

        if(changeBoard){
            lerpTime += Time.deltaTime;
            float percentCompleted = lerpTime/lerpSpeed;
            Vector2.Lerp(transform.localScale, finalScale, percentCompleted);

            if((Vector2)transform.localScale == finalScale) lerpTime = 0;
        }

        else if(!changeBoard){
            lerpTime += Time.deltaTime;
            float percentCompleted = lerpTime/lerpSpeed;
            Vector2.Lerp(transform.localScale, initialScale, percentCompleted);

            if((Vector2)transform.localScale == initialScale) lerpTime = 0;
        }
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero) {
            rigidbody.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnDestroy(){
        GameEvents.current.OnBoardPowerUp -= ChangeBoard;
    }

}

