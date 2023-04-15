using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public char ch;
    // Start is called before the first frame update
    void Start()
    {
        switch(char.ToUpper(ch)){
            case 'A': case 'E': case 'I': case 'O': case 'U':
            Debug.Log("Vowel");
            break;
            default:
            Debug.Log("Consonant");
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
