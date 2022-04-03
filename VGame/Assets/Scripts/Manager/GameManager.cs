using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int hp;
    public int pain;
    public int score;
    public int damage; // 입히는 데미지
    public int increaseDamage; // 증가 데미지
    public int bulletLevel;
    public bool isShield;
    public bool isUndamageCheat;
    

    public Text timeText;
    public Text scoreText;
    public Text hpText;
    public Text painText;

    public Slider hpSlider;
    public Slider painSlider;

    public EnemySpawn enemySpawn;
    public EnemySpawn[] enemySpawners;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        hp = 100;
        pain = 10;
        score = 0;
        damage = 10;
        bulletLevel = 1;
        isShield = false;
        hpSlider.value = hp;
        painSlider.value = pain;
        hpText.text = "체력: " + hp + "%";
        painText.text = "고통: " + pain + "%";
        scoreText.text = "Score: " + score;
        
        // 치트
        isUndamageCheat = false;
        // if()
        // 고통 값

    }


    void Update()
    {
        CheatKey();
    }

    public void Heal(int healPoint)
    {
        if (hp + healPoint > 100)
        {
            hp = 100;
            hpSlider.value = hp;
            hpText.text = "체력: " + hp + "%";
        }
        else
        {
            hp += healPoint;
            hpSlider.value = hp;
            hpText.text = "체력: " + hp + "%";
        }
    }

    public void Damage(int damage)
    {
        if (hp - damage > 0)
        {
            hp -= damage;
            hpSlider.value = hp;
            hpText.text = "체력: " + hp + "%";
            
        }
        else if (hp - damage <= 0)
        {
            hp = 0;
            hpSlider.value = hp;
            hpText.text = "체력: " + hp + "%";
            GameOver();
        }
    }

    public void GetPain(int getPain)
    {
        if (pain + getPain >= 100)
        {
            pain = 100;
            painSlider.value = pain;
            painText.text = "고통: " + pain + "%";
            GameOver();
        }
        else
        {
            pain += getPain;
            painSlider.value = pain;
            painText.text = "고통: " + pain + "%";
        }
    }

    public void ReducePain(int reducePain)
    {
        if (pain - reducePain < 0)
        {
            pain = 0;
            painSlider.value = pain;
            painText.text = "고통: " + pain + "%";
        }
        else
        {
            pain -= reducePain;
            painSlider.value = pain;
            painText.text = "고통: " + pain + "%";
        }
    }

    public void AddScore(int getScore)
    {
        score += getScore;
        scoreText.text = "Score: " + score;
    }

    public IEnumerator ShieldCoroutine()
    {
        if (!isUndamageCheat)
        {
            isShield = true;
            Debug.Log("ShieldCoroutine is Working" + Time.time);
            yield return new WaitForSeconds(3f);
            isShield = false;
            Debug.Log("isShield == false"); // 지워라
        }
    }

    public void BulletLevel()
    {
        if (bulletLevel < 5)
        {
            bulletLevel++;
        }
        damage = bulletLevel * 10; // 증가 공격력 단위를 바꾸고 싶다면 따로 increaseDamage 변수를 만들어서 처리해줘
    }

    public void GameOver()
    {
        SceneManagement.sceneManager.NextScene("GameOver");
        // 랭킹 시스템 창으로 이동
    }

    public void CheatKey() // 치트키
    {
        if (Input.GetKeyDown(KeyCode.U)) // 회복 치트
        {
            Heal(10);
        }
        if (Input.GetKeyDown(KeyCode.I)) // 고통 감소 치트
        {
            ReducePain(10);
        }
        if (Input.GetKeyDown(KeyCode.O)) // 피해 치트
        {
            Damage(10);
        }
        if (Input.GetKeyDown(KeyCode.P)) // 고통 증가 치트
        {
            GetPain(10);
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket)) // 백혈구 소환 치트 enemies[4]
        {
            Instantiate(enemySpawn.enemies[4], enemySpawners[Random.Range(0, 4)].transform.position,
                transform.rotation);
            Debug.Log("백혈구");
        }
        if (Input.GetKeyDown(KeyCode.RightBracket)) // 적혈구 소환 치트 enemies[5]
        {
            Instantiate(enemySpawn.enemies[5], enemySpawners[Random.Range(0, 4)].transform.position,
                transform.rotation);
            Debug.Log("적혈구");
        }

        if (Input.GetKeyDown(KeyCode.J)) // 무적 치트
        {
            isUndamageCheat = !isUndamageCheat;
        }
    }
}
