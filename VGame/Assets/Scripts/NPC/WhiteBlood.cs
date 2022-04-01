using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WhiteBlood : Enemy
{
    public GameObject[] item;
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
            switch (itemNumber) // 아이템 랜덤 생성
            {
                case 0:
                    Instantiate(item[0], transform.position, transform.rotation);
                    break;
                case 1:
                    Instantiate(item[1], transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(item[2], transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(item[3], transform.position, transform.rotation);
                    break;
                case 4:
                    Instantiate(item[4], transform.position, transform.rotation);
                    break;
                case 5:
                    Instantiate(item[5], transform.position, transform.rotation);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
