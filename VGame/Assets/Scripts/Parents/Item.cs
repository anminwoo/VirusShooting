using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type;
    protected Rigidbody2D rigid;

    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    protected void Update()
    {
        rigid.velocity = Vector2.down * 1.5f;
    }
}
