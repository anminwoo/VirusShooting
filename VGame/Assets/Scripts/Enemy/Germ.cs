using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : Enemy
{
    public Bullet GermBullet;
    void Start()
    {
        hp = 30;
        damage = 20;
        speed = 1f;
        nextFire = 1f;
        score = 300;
    }
    
    void Update()
    {
        Move();
        Shoot(GermBullet);
    }
}
