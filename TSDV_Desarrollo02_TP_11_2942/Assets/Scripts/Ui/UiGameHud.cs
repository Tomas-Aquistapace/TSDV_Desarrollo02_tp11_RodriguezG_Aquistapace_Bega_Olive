using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiGameHud : MonoBehaviour
{
    public Player player;
    public Image life;
    public TextMeshProUGUI textEnemies;
    public TextMeshProUGUI textTime;
    private LevelGenerator levelGenerator;
    private float onTime;

    private void Awake()
    {
        levelGenerator = GetComponent<LevelGenerator>();
    }

    void Start()
    {
        Time.timeScale = 1;
    }
    
    void Update()
    {
        onTime += Time.deltaTime;
        life.fillAmount = player.energy / (float)player.maxEnergy;
        textTime.text = "Time: " + onTime.ToString("F2");
        textEnemies.text = "Enemies Kill: " + levelGenerator.totalEnemies;
    }

    public void Pause()
    {
        levelGenerator.onGame = !levelGenerator.onGame;
    }
}
