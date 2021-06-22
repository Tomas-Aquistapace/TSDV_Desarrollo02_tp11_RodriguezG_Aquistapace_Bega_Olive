using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public Player player;
    public LevelGenerator levelGenerator;
    public int score;
    public float enemyKilled;
    public float lapsedTime;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
    void Start()
    {
        player.OnDie += SaveDataGame;
    }

    void Update()
    {
        
    }

    void SaveDataGame()
    {
        score = levelGenerator.score;
        lapsedTime = levelGenerator.timePlayed;
        enemyKilled = levelGenerator.totalEnemies;
        SceneManager.LoadScene("GameOver");
    }
}
