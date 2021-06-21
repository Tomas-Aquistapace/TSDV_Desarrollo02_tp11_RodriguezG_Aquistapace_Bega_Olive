using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour, ItakeDamage
{
    public float speed = 30f;
    public GameObject player;
    //public int score = 100;
    [SerializeField] Animator anim;


    //private float timeToExplode = 0.8f;
    private float onTime;
    private int damageKamikaze = 20;
    private bool destroyed;
    private LevelGenerator.EnemyType enemyType = LevelGenerator.EnemyType.End;


    public void SetEnemy(LevelGenerator.EnemyType enemyType, GameObject player)
    {
        this.player = player;
        this.enemyType = enemyType;
    }

    private void Start()
    {
        if (player)
            player = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        onTime = Time.deltaTime;
        Vector3 objetive = player.transform.position;
        Vector3 direction = objetive - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime));

        transform.LookAt(objetive);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player" && !destroyed)
        {
            destroyed = true;
            other.transform.GetComponent<Player>().TakeDamage(damageKamikaze);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        anim.SetBool("IsDead", true);
        transform.GetComponent<CircleCollider2D>().enabled = false;

        Destroy(this.gameObject, 1f);
    }
}