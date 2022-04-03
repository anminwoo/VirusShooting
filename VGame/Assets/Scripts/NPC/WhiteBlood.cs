using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WhiteBlood : Enemy
{
    public Item[] items;
    void Start()
    {
        hp = 1;
        damage = 0;
        speed = 1f;
        score = 300;
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other) // enemy의 Trigger와 달라서 enemy 태그 필요없음
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBullet")
        {
            int itemNumber = UnityEngine.Random.Range(0, 6);
            Debug.Log(itemNumber);
            if (other.gameObject.tag == "PlayerBullet")
            {
                Destroy(other.gameObject); // 총알 파괴
            }
            switch (itemNumber) // 아이템 랜덤 생성
            {
                case 0:
                    Instantiate(items[0], transform.position, transform.rotation);
                    break;
                case 1:
                    Instantiate(items[1], transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(items[2], transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(items[3], transform.position, transform.rotation);
                    break;
                case 4:
                    Instantiate(items[4], transform.position, transform.rotation);
                    break;
                case 5:
                    Instantiate(items[5], transform.position, transform.rotation);
                    break;
            }
            Destroy(gameObject); // 백혈구 파괴
        }
    }
}
