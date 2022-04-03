using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 꼭 들어가야하는거
    protected int hp;
    public int damage;
    public int score;
    protected float speed;
    // NPC에 필요한 것
    public int pain;
    
    // 총알 발사 능력있는 친구들
    protected float fireRate;
    protected float nextFire; // 발사빈도
    
    private Rigidbody2D rigid;
    private CircleCollider2D collider;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    protected void Move() // 이동
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    protected void Shoot(Bullet enemyBullet) // 총알 하나
    {
        if (Time.time > fireRate)
        {
            fireRate = nextFire + Time.time;
            Instantiate(enemyBullet, transform.position, transform.rotation);
        }
    }

    protected void Shoot(Bullet enemyBullet, int bulletCount, float angle) // 총알 갯수와 각도 지정
    {
        float bulletAngle = angle / bulletCount; // 발사 후 더해줄 각도
        float fireAngle = -bulletAngle; // 발사각도
        if (Time.time > fireRate)
        {
            fireRate = nextFire + Time.time;
            for (int i = 0; i < bulletCount; i++)
            {
                Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, fireAngle));
                fireAngle += bulletAngle;
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemyInstance = GetComponent<Enemy>(); // 부딪친 enemyInstance에 대한 정보를 가져옴
        
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.AddScore(enemyInstance.score);
            Debug.Log("Enemy OnTriggerEnter2D");
            Destroy(gameObject);
        }
        
        else if (other.gameObject.tag == "PlayerBullet")
        {
            hp -= GameManager.instance.damage;
            Debug.Log(GameManager.instance.damage + "만큼의 데미지를 받았습니다!");
            Debug.Log(hp + "남았습니다!");
            Destroy(other.gameObject); // 총알 파괴
            if (hp <= 0)
            {
                GameManager.instance.AddScore(enemyInstance.score);
                Destroy(gameObject);
            }
        }
    }
}
