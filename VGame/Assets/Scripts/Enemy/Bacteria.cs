using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bacteria : Enemy
{

    void Start()
    {
        hp = 30;
        damage = 10;
        speed = 1f;
        score = 200;
    }

    void Update()
    {
        Move();
    }
}
