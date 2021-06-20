using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public bool onDebug;
    public GameObject pfEnemy;
    public GameObject pfPlayer;
    public GameObject[] spawners;
    public Transform enemiesGroup;

    public enum EnemyType
    {
        Horizontal,
        Vertical,
        Kamikaze,
        End
    };

    private int level = 1;
    private float dificultMultiply = 3;
    private float onTimeLevel;
    
    public class Enemies
    {
        public float ontime;
        public float rateSpawn;
    }

    private List<Enemies> enemies = new List<Enemies>();

    private void Start()
    {
        for (int i = 0; i < (int)EnemyType.End; i++)
        {
            Enemies enemy = new Enemies();          // todo: Chequear si está bien y no genero un puntero
            enemy.rateSpawn = dificultMultiply + ((float)i / 3.0f) * (float)level;
            enemies.Add(enemy);
        }
    }

    void ProgressEquation()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].rateSpawn *= 0.9f;
        }
    }

    void Update()
    {
        onTimeLevel += Time.deltaTime;

        CheckSpawnEnemy();
    }

    void CheckSpawnEnemy()
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

            SpawnEnemy(enemyPosSpawn, (EnemyType) i);
        }
    }

    void SpawnEnemy(Vector3 pos, EnemyType enemyType)
    {
        if (onDebug) Debug.Log("Enemigo en: " + pos);
        //GameObject enemy = Instantiate(pfEnemy, pos, Quaternion.identity, enemiesGroup);
        //enemy.GetComponent<Enemy>().SetEnemy(enemyType, player);
    }

    void EnemyDirection()
    {
        
    }
}