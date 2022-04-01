using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBullet : Bullet
{
    void Start()
    {
        damage = 30;
    }
    
    void Update()
    {
        Move(Vector3.down, 10f);
    }
}
