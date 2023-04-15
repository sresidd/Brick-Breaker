using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{

    public static float ReturnHalfScreenWidth(){
        return ReturnHalfScreenHeight() * Camera.main.aspect;
    }

    public static float ReturnHalfScreenHeight(){
        return Camera.main.orthographicSize;
    }
}
