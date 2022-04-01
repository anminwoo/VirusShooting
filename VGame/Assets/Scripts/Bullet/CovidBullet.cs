using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidBullet : Bullet
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
