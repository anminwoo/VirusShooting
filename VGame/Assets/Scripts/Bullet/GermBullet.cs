using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermBullet : Bullet
{
    
    void Start()
    {
        damage = 20;
    }
    
    void Update()
    {
        Move(Vector3.down, 10f);
    }
}
