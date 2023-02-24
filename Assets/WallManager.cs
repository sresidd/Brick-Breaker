using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] 
    private Transform upperWall,
                        lowerWall,
                        rightWall,
                        leftWall;


    [SerializeField]
    private Vector2 offset;


    void Start()
    {
        upperWall.position = new Vector2(0,ScreenSize.ReturnHalfScreenHeight() + offset.y);
        lowerWall.position = new Vector2(0,-ScreenSize.ReturnHalfScreenHeight() - offset.y);
        rightWall.position = new Vector2(ScreenSize.ReturnHalfScreenWidth() + offset.x,0);
        leftWall.position = new Vector2(-ScreenSize.ReturnHalfScreenWidth() - offset.x,0);
        transform.position += (Vector3)Vector2.up;
    }
}
