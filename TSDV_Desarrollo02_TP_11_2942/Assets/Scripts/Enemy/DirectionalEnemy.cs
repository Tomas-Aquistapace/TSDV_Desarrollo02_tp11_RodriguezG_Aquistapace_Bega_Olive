using UnityEngine;

public class DirectionalEnemy : MonoBehaviour, ItakeDamage
{
    [Header("Limits of enemy")]
    public float rightEdge;
    public float leftEdge;
    public float topEdge;
    public float downEdge;

    public enum DirectionState
    {
        MovingForward,
        MovingBack
    }
    DirectionState currentState;

    [Header("Enemy Gun")]
    public float speed = 10;
    public float delayBullet = 1f;
    public GameObject gun;

    Vector3 direction;
    float time;

    void Start()
    {
        time = 0;
    }

    void OnEnable()
    {
        currentState = DirectionState.MovingForward;
        direction = GetDirection();
    }

    void Update()
    {
        DelayShoot();
    }

    void DelayShoot()
    {
        time += Time.deltaTime;
        if (time > delayBullet)
        {
            gun.GetComponent<IcanShoot>().ShootGun();
            time = 0;
        }
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case DirectionState.MovingForward:
                transform.Translate(direction * speed * Time.deltaTime);
                if (ChangeDirection()) currentState = DirectionState.MovingBack;
                break;
            case DirectionState.MovingBack:
                transform.Translate(-direction * speed * Time.deltaTime);
                if (ChangeDirection()) currentState = DirectionState.MovingForward;
                break;
            default:
                break;
        }
    }

    Vector3 GetDirection()
    {
        if (transform.position.x < leftEdge)
            return Vector3.right;
        if (transform.position.x > rightEdge)
            return Vector3.left;
        if (transform.position.y > topEdge)
            return Vector3.down;
        if (transform.position.y < downEdge)
            return Vector3.up;

        return Vector3.zero;
    }

    bool ChangeDirection()
    {
        if (currentState == DirectionState.MovingForward)
        {
            if (direction == Vector3.right) return transform.position.x >= rightEdge;
            if (direction == Vector3.left) return transform.position.x <= leftEdge;
            if (direction == Vector3.down) return transform.position.y <= downEdge;
            if (direction == Vector3.up) return transform.position.y >= topEdge;
        }
        else
        {
            if (direction == Vector3.right) return !(transform.position.x >= leftEdge);
            if (direction == Vector3.left) return !(transform.position.x <= rightEdge);
            if (direction == Vector3.down) return transform.position.y >= topEdge;
            if (direction == Vector3.up) return !(transform.position.y >= downEdge);
        }
        return true;
    }

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
