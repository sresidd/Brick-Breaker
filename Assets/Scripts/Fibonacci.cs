using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    private int num1 = 0, num2 = 1, sum = 0;
    [SerializeField] private int term;
    // Start is called before the first frame update
    void Start()
    {
        FibonaccI(term);
    }

    private void FibonaccI(int n_term){
        for(int i = 0;i<n_term;i++){
            sum = num1 + num2;
            Debug.Log(sum);
            num1 = num2;
            num2 = sum;
        }
    }
}
