using UnityEngine;

public class Source : MonoBehaviour
{
    public delegate void NewSource();

    // public System.Func<int,string> newSource;

    public static NewSource newS;

    int number;
    void Awake()
    {
        newS += Hello;
        // newSource += Yellow;
        // newSource.Invoke();

        // Debug.Log(Hello() + " " + Yellow());
    }

    private void Hello()
    {
        Debug.Log("hello");
    }

    private int Yellow(){
        return 20;
    }
}
