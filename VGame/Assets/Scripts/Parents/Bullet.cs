using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    protected float speed; // 있지만 사용안함

    private CapsuleCollider2D collider;
    
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
    }

    protected void Move(Vector2 dir, float speed) // 발사 방향과 스피드
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
