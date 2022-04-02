using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlood : Enemy
{

    void Start()
    {
        hp = 1;
        damage = 0;
        score = 100;
        speed = 1.5f;
        pain = 20;
    }

    void Update()
    {
        Move();
    }
}
