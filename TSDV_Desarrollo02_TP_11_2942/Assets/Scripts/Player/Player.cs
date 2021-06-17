using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ItakeDamage, Ikillable
{
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
    public int energy = 100;
    public int speedEnergyDrops = 2;
    public bool isDead = false;

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
        if (Input.GetKeyDown("space"))
        {
            if(standarGun.activeSelf == true) { standarGun.GetComponent<IcanShoot>().ShootGun(); }
            if(machineGun.activeSelf == true) { machineGun.GetComponent<IcanShoot>().ShootGun(); }
            if(rocketLauncher.activeSelf == true) { rocketLauncher.GetComponent<IcanShoot>().ShootGun(); }
            if(railgun.activeSelf == true) { railgun.GetComponent<IcanShoot>().ShootGun(); }
        }
    }

    public void TakeDamage(int damage)
    {
        energy -= damage;

        isDead = Killable(energy);
    }

    public bool Killable(int value)
    {
        return value <= 0;
    }
}
