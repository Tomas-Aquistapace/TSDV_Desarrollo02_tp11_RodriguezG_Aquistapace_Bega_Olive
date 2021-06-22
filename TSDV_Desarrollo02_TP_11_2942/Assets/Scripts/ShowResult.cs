using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public Sprite sprite;
    public GameObject panelButton;
    private Camera cam;
    private SaveData saveData;

    public TextMeshProUGUI text;


    public int score;
    public float enemyKilled;
    public float lapsedTime;

    private void Awake()
    {
        cam = Camera.main;
    }

    void Start()
    {
        saveData = FindObjectOfType<SaveData>();
        panelButton.GetComponent<Image>().sprite = sprite;
        score = saveData.score;
        enemyKilled = saveData.enemyKilled;
        lapsedTime = saveData.lapsedTime;
        Destroy(saveData.gameObject);
        text.text = "Score: " + score + "\nEnemies Killed: " + enemyKilled + "\nTime: " + lapsedTime.ToString("F2");
    }
}
