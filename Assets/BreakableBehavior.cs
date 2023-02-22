using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreakableBehavior : MonoBehaviour
{
    [SerializeField] TMP_Text countTxt;
    private int counter = 3;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        // GenerateRandomColor();
        countTxt.text = counter.ToString();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.red;

    }

    private void GenerateRandomColor()
    {
        // float red = Random.Range(0f,1f);
        // float blue = Random.Range(0f,1f);
        // float green = Random.Range(0f,1f);
        // GetComponent<SpriteRenderer>().color = new Color(red,blue,green,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("ball")){
            counter--;
            countTxt.text = counter.ToString();

            switch(counter){
                case 2: spriteRenderer.color = Color.green;
                break;

                case 1:
                spriteRenderer.color = Color.blue;
                break;

                case 0: Destroy(this.gameObject);
                break;
            }
            // if(counter<1)Destroy(this.gameObject);
            // // Destroy(this.gameObject);
        }
    }
}
