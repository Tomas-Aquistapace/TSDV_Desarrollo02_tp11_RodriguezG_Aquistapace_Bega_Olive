using System;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 2f;
    public int damage = 10;
    public float speed;
    Vector3 playerPos;
    Vector3 initialPos;
    Vector3 direction;
    private LevelGenerator levelGenerator;
    private float onTime;
    private void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }

    private void Start()
    {
        playerPos = FindObjectOfType<Player>().transform.position;
        initialPos = transform.position;

        direction = playerPos - initialPos;

        
    }

    void Update()
    {
        
        if (levelGenerator.onGame)
        {
            onTime += Time.deltaTime; 
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            if (onTime > timeToDestroy)
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<ItakeDamage>()?. TakeDamage(damage);

        Destroy(this.gameObject);
    }
}