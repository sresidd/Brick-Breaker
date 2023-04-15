using UnityEngine;

public class PrimeNumberCheck : MonoBehaviour
{

    [SerializeField] private int given_number;
    // Start is called before the first frame update
    void Start()
    {
        if(IsPrime(given_number)){
          Debug.Log(given_number + " is prime.");  
        }
        else{
            Debug.Log(given_number + " is composite.");
        }
    }

    private bool IsPrime(int number){
        if(number <= 1 ) return false;
        if(number ==2 ) return true;
        if(number % 2 == 0) return false;

        Debug.Log(Mathf.Sqrt(number));

        for(int i = 3;i< Mathf.Sqrt(number);i+=2){
            if(number % i == 0) return false;
        }

        return true;
    }
}
