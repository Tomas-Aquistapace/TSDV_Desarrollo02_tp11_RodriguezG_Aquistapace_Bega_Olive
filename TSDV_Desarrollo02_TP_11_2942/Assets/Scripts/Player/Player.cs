﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Player : MonoBehaviour, ItakeDamage, Ikillable
{
    public Action OnDie;

    [Header("Limits of player")]
    [SerializeField]
    private float rightEdge = 85f;
    [SerializeField]
    private float leftEdge = -85f;
    [SerializeField]
    private float topEdge = 76;
    [SerializeField]
    private float downEdge = -16.5f;

    [Header("Values of player")]
    [SerializeField]
    private float speedMovement;
    public int maxEnergy = 100;
    public int energy = 100;
    public int speedEnergyDrops = 5;
    public bool isDead;
    public float rateShoot = 0.3f;
    private float onTime;
    public int score;
    public float playedTime;

    [Header("Player Guns")]
    public GameObject standarGun;
    public GameObject machineGun;
    public GameObject rocketLauncher;
    public GameObject railgun;

    float collRadius;

    private void Start()
    {
        collRadius = transform.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        float deltaT = Time.deltaTime;

        playedTime += deltaT;
        onTime += deltaT;

        InputShots();
    }

    void FixedUpdate()
    {
        InputMovement();
    }

    void InputMovement()
    {
        float x = Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal"), leftEdge + collRadius, rightEdge - collRadius);
        float y = Mathf.Clamp(transform.position.y + Input.GetAxis("Vertical"), downEdge + collRadius, topEdge - collRadius);

        transform.position = new Vector3(x, y, 0) * speedMovement * Time.deltaTime;
    }

    void InputShots()
    {
        if (Input.GetKey("space"))
        {
            if (onTime > rateShoot)
            {
                onTime = 0;
                if (standarGun.activeSelf == true)
                {
                    standarGun.GetComponent<IcanShoot>().ShootGun();
                }

                if (machineGun.activeSelf == true)
                {
                    machineGun.GetComponent<IcanShoot>().ShootGun();
                }

                if (rocketLauncher.activeSelf == true)
                {
                    rocketLauncher.GetComponent<IcanShoot>().ShootGun();
                }

                if (railgun.activeSelf == true)
                {
                    railgun.GetComponent<IcanShoot>().ShootGun();
                }
            }
        }
    }

    public void RestoreEnergy(int amount)
    {
        energy += amount;
        if (energy > maxEnergy) { energy = maxEnergy; }
    }

    public void TakeDamage(int damage)
    {
        energy -= damage;

        isDead = Killable(energy);
    }

    public bool Killable(int value)
    {
        if (value > 0)
        {
            return false;
        }
        OnDie?.Invoke();
        return true;
    }
}
