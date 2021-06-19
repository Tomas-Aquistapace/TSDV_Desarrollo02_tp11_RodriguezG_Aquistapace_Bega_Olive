using UnityEngine;
public class BulletEnemy : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 2f;
    public int damage = 10;
    public float speed;
    Vector2 playerPos;
    private void Start()
    {
        playerPos = FindObjectOfType<Player>().transform.position;
        playerPos.Normalize();
    }
    void Update()
    {
        transform.Translate(playerPos * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<ItakeDamage>()?.TakeDamage(damage);
    }
}