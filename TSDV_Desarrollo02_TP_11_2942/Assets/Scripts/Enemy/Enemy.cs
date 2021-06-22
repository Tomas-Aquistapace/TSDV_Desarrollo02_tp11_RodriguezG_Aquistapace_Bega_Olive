using UnityEngine;

public class Enemy : MonoBehaviour, ItakeDamage
{
    public int score;
    public float speed = 40f;
    public GameObject player;

    [SerializeField] Animator anim;
    
    private float timeToExplode = 1f;
    private float onTime;
    private int damageKamikaze = 20;
    private bool destroyed;
    private LevelGenerator levelGenerator;
    private void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
        player = FindObjectOfType<Player>().gameObject;
    }

    private void Start()
    {
        if (!player)
            player = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        onTime = Time.deltaTime;
        Vector3 objetive = player.transform.position;
        Vector3 direction = objetive - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player" && !destroyed)
        {
            destroyed = true;
            other.transform.GetComponent<Player>().TakeDamage(damageKamikaze);
            TakeDamage(0);
        }
    }

    public void TakeDamage(int damage)
    {
        anim.SetBool("IsDead", true);
        transform.GetComponent<CircleCollider2D>().enabled = false;

        Destroy(this.gameObject, timeToExplode);
        levelGenerator.enemies[1].enemiesCount--;
        levelGenerator.enemyKilledCount++;
        levelGenerator.score += score;
        levelGenerator.totalEnemies ++;
    }
}