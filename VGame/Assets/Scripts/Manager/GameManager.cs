using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int hp;
    public int pain;
    public int score;
    public int damage;
    public int bulletLevel;
    public bool isSheld;
    

    public Text timeText;
    public Text scoreText;
    public Text hpText;
    public Text painText;

    public Slider hpSlider;
    public Slider painSlider;

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
        isSheld = false;
        hpSlider.value = hp;
        painSlider.value = pain;
        hpText.text = "체력: " + hp + "%";
        painText.text = "고통: " + pain + "%";
        scoreText.text = "Score: " + score;
        
        // if()
        // 고통 값

    }


    void Update()
    {
        
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
        isSheld = true;
        yield return new WaitForSeconds(3f);
    }

    public void BulletLevel()
    {
        damage = damage * bulletLevel;
    }

    public void GameOver()
    {
        SceneManagement.sceneManager.NextScene("GameOver");
        // 랭킹 시스템 창으로 이동
    }
}
