using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    public Bullet VirusBullet;
    void Start()
    {
        hp = 50;
        damage = 30;
        speed = 0.8f;
        score = 400;

        fireRate = 0;
        nextFire = 1.5f;
    }

    void Update()
    {
        Move();
        Shoot(VirusBullet, 3, 120f);
    }
}
