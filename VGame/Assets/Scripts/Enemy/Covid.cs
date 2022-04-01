using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Covid : Enemy
{
    public Bullet covidBullet;
    
    void Start()
    {
        hp = 3000;
        damage = 20;
        score = 10000;
        
        fireRate = 0;
        nextFire = 2f;
    }

    void Update()
    {
        StartCoroutine(PatternCoroutine());
    }

    void OneShoot() // 한번 쏘기
    {
        Shoot(covidBullet);
    }

    void TripleShoot() // 세번 쏘기
    {
        Shoot(covidBullet, 3, 36);
    }

    void RoundShoot() // 8방향 발사
    {
        Shoot(covidBullet, 8, 360);
    }

    IEnumerator PatternCoroutine()
    {
        int selectShoot = Random.Range(1, 4);
        switch (selectShoot)
        {
            case 1:
                OneShoot();
                break;
            case 2:
                TripleShoot();
                break;
            case 3:
                RoundShoot();
                break;
        }

        yield return new WaitForSeconds(3f);
    }
    
}
