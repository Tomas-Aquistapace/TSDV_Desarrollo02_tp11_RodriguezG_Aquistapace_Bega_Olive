using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public Sprite[] sprite; // 1: Win 2: Lose
    private int win;
    public GameObject panelButton;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        panelButton.GetComponent<Image>().sprite = sprite[win];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
