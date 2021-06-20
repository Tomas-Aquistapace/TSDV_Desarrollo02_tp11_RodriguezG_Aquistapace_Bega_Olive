using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private bool alive = true;
    public Player player;
    private int score;
    private float enemyKilled;
    private float lapsedTime;

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
        score = player.score;
        lapsedTime = player.playedTime;



        alive = false;
    }
}
