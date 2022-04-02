using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnRate = 1.5f;
    public Enemy[] enemies;
    void Start()
    {
        
    }

    void Update()
    {
        EnemySpawnCouroutine();
    }

    IEnumerator EnemySpawnCouroutine()
    {
        int enemyNumber = Random.Range(0, 6);
        Instantiate(enemies[enemyNumber], transform.position, transform.rotation);
        yield return new WaitForSeconds(spawnRate);
    }
    
}
