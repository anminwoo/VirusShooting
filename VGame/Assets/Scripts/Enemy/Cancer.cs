using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : Enemy
{
    public Bullet CancerBullet;
    void Start()
    {
        hp = 80;
        damage = 30;
        speed = 0.8f;
        score = 500;
        
        fireRate = 0;
        nextFire = 2f;
    }


    void Update()
    {
        Move();
        Shoot(CancerBullet, 4, 360);
    }
}
