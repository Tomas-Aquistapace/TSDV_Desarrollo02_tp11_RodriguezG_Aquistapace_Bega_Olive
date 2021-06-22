using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public bool onGame = true;
    public bool onDebug;
    public int score;
    public GameObject[] spawners;
    public Transform enemiesGroup;
    public int totalEnemies;
    public int level = 1;
    private float dificultMultiply = 3;
    public float timePlayed;

    private int enemyKilledPerLevel = 5;
    public int enemyKilledCount;

    [Serializable] public class Enemies
    {
        public GameObject pfEnemy;
        [HideInInspector] public float ontime;
        public float rateSpawn;
        public int enemiesCount;
        public int maxEnemies;
    }

    [SerializeField] public List<Enemies> enemies = new List<Enemies>();
    
    void ProgressEquationLevel()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].rateSpawn *= 0.9f;
        }

        level++;
        enemyKilledPerLevel = enemyKilledPerLevel * (1 + 1 / level);
        enemyKilledCount = 0;
    }

    void Update()
    {
        if (onGame)
        {
            timePlayed += Time.deltaTime;
            CheckSpawnEnemy();
        }
    }

    void CheckSpawnEnemy()
    {
        if (enemyKilledCount < enemyKilledPerLevel)
        {
            float deltaT = Time.deltaTime;

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].ontime += deltaT;
                if (enemies[i].ontime < enemies[i].rateSpawn)
                    continue;

                enemies[i].ontime = 0;

                int enemySpawn = Random.Range(0, spawners.Length);
                Transform spawn = spawners[enemySpawn].transform;

                int width = (int) (spawn.localScale.x / 2);
                int height = (int) (spawn.localScale.y / 2);

                Vector3 enemyPosSpawn = Vector3.zero;
                enemyPosSpawn.x = Random.Range(0, width) + (int) spawn.position.x;
                enemyPosSpawn.y = Random.Range(0, height) + (int) spawn.position.y;

                if (enemies[i].enemiesCount < enemies[i].maxEnemies)
                    SpawnEnemy(enemyPosSpawn, i);
            }
        }
        else
        {
            ProgressEquationLevel();
        }
    }

    void SpawnEnemy(Vector3 pos, int i)
    {
        if (onDebug) Debug.Log("Enemigo en: " + pos);
        GameObject enemy = Instantiate(enemies[i].pfEnemy, pos, Quaternion.identity, enemiesGroup);
        enemies[i].enemiesCount++;
    }
}