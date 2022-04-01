using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.5f;
    public PlayerBullet playerBullet;
    
    private Rigidbody2D rigid;
    private BoxCollider2D collider;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // 플레이어 이동
        float horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontal, vertical, 0);

        // 카메라 밖으로 못나가게 함.
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Covid")
        {
            Enemy enemyInstance = other.gameObject.GetComponent<Enemy>();
            if (GameManager.instance.isSheld == false) // 무적 상태가 아니라면
            {
                GameManager.instance.Damage(enemyInstance.damage / 2);
            }
            if (other.gameObject.tag != "Covid")
            {
                Destroy(other.gameObject);
            }
        }

        else if (other.gameObject.tag == "EnemyBullet")
        {
            Bullet enemyBulletInstance = other.gameObject.GetComponent<Bullet>();
            if (GameManager.instance.isSheld == false) // 무적 상태가 아니라면
            {
                GameManager.instance.Damage(enemyBulletInstance.damage);
            }
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Item")
        {
            Item item = other.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Heal":
                    GameManager.instance.Heal(30);
                    break;
                case "PainKiller":
                    GameManager.instance.ReducePain(20);
                    break;
                case "PowerUp":
                    GameManager.instance.bulletLevel++;
                    Debug.Log(GameManager.instance.bulletLevel); // 나중에 지워줘
                    GameManager.instance.BulletLevel();
                    break;
                case "ScoreUp":
                    GameManager.instance.AddScore(1000);
                    break;
                case "Sheld":
                    if (GameManager.instance.isSheld)
                    {
                        StopCoroutine(GameManager.instance.SheldCoroutine());
                    }
                    GameManager.instance.SheldCoroutine();
                    break;
                case "Unknown":

                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
