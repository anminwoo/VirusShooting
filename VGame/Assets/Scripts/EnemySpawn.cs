using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnRate;
    public float nextSpawn;
    public Enemy[] enemies;
    void Start()
    {
        spawnRate = 1.5f;
    }

    void Update()
    {
        SpawnEnemy();
        // StartCoroutine(EnemySpawnCoroutine());
    }

    void SpawnEnemy()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int enemyNumber = Random.Range(0, 6);
            Instantiate(enemies[enemyNumber], transform.position, transform.rotation);
        }
    }
    
    // IEnumerator EnemySpawnCoroutine()
    // {
    //     int enemyNumber = Random.Range(0, 6);
    //     Instantiate(enemies[enemyNumber], transform.position, transform.rotation);
    //     Debug.Log("Working" + Time.time);
    //
    //     yield return new WaitForSeconds(1f);
    // }
}
