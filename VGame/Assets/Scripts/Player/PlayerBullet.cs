using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBullet : Bullet
{
    
    void Start()
    {
        speed = 10f;
    }
    
    void Update()
    {
        Move(Vector2.up, speed);
    }
}
