using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DirectionalEnemy : MonoBehaviour, ItakeDamage
{
    private LevelGenerator levelGenerator;

    public int score;

    [Header("Limits of enemy")]
    public float topEdge;
    public float downEdge;
    public float leftEdge;
    public float rightEdge;

    public enum DirectionAxis
    {
        TopToDown,
        LeftToRight
    }
    public DirectionAxis directionAxis;

    enum DirectionState
    {
        MovingForward,
        MovingBack
    }
    DirectionState currentState;

    [Header("Enemy Gun")]
    public float speed = 2;
    public float delayBullet = 1f;
    public GameObject body;
    public GameObject gun;

    [SerializeField] Animator anim;

    //private Vector3 direction;
    private bool destroyed;
    private float time;
    private float moveTime;

    Vector3 topVec;
    Vector3 downVec;
    Vector3 leftVec;
    Vector3 rightVec;

    bool initialDirec;  
    // false == top or left
    // true == down or right

    private void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }

    void Start()
    {
        time = 0;
        moveTime = 0;

        topVec = new Vector3(transform.position.x, topEdge, 0);
        downVec = new Vector3(transform.position.x, downEdge, 0);
        leftVec = new Vector3(leftEdge, transform.position.y, 0);
        rightVec = new Vector3(rightEdge, transform.position.y, 0);
    }

    void OnEnable()
    {
        if (transform.position.y > topEdge + 5f)
        {
            directionAxis = DirectionAxis.TopToDown;
        }
        else
        {
            directionAxis = DirectionAxis.LeftToRight;
            if(transform.position.x > 0)
            {
                body.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                body.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }

        switch (directionAxis)
        {
            case DirectionAxis.TopToDown:

                if (transform.position.y > 0)
                {
                    currentState = DirectionState.MovingForward;
                    initialDirec = false;
                }
                else if (transform.position.y < 0)
                {
                    currentState = DirectionState.MovingBack;
                    initialDirec = true;
                }

                break;
            case DirectionAxis.LeftToRight:

                if (transform.position.x < 0)
                {
                    currentState = DirectionState.MovingForward;
                    initialDirec = false;
                }
                else if (transform.position.x > 0)
                {
                    currentState = DirectionState.MovingBack;
                    initialDirec = true;
                }

                break;
        }        
    }

    void Update()
    {
        if (levelGenerator.onGame)
        {
            if (!destroyed)
                DelayShoot();
        }
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
        if (levelGenerator.onGame)
        {
            switch (directionAxis)
            {
                case DirectionAxis.TopToDown:

                    if (transform.position.y > topVec.y)
                    {
                        transform.Translate(new Vector3(0, downEdge, 0) * (speed / 4f) * Time.deltaTime);
                    }
                    else if (transform.position.y < downVec.y)
                    {
                        transform.Translate(new Vector3(0, topEdge, 0) * (speed / 4f) * Time.deltaTime);
                    }
                    else
                    {
                        if (!initialDirec)
                            MoveEntity(topVec, downVec);
                        else
                            MoveEntity(downVec, topVec);
                    }

                    break;
                case DirectionAxis.LeftToRight:

                    if (transform.position.x < leftVec.x)
                    {
                        transform.Translate(new Vector3(rightEdge, 0, 0) * (speed / 4f) * Time.deltaTime);
                    }
                    else if (transform.position.x > rightVec.x)
                    {
                        transform.Translate(new Vector3(leftEdge, 0, 0) * (speed / 4f) * Time.deltaTime);
                    }
                    else
                    {
                        if (!initialDirec)
                            MoveEntity(leftVec, rightVec);
                        else
                            MoveEntity(rightVec, leftVec);
                    }

                    break;
            }
        }
    }

    
    void MoveEntity(Vector3 A, Vector3 B)
    {
        transform.position = Vector3.Lerp(A, B, moveTime);
        
        if(currentState == DirectionState.MovingForward)
        {
            moveTime += (speed / 4f) * Time.deltaTime;

            if(moveTime >= 1)
            {
                if (directionAxis == DirectionAxis.TopToDown)
                {
                    body.transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                else
                {
                    body.transform.rotation = Quaternion.Inverse(body.transform.rotation);
                }

                currentState = DirectionState.MovingBack;
                moveTime = 1;
            }
        }
        else if (currentState == DirectionState.MovingBack)
        {
            moveTime -= (speed / 4f) * Time.deltaTime;

            if (moveTime <= 0)
            {
                if (directionAxis == DirectionAxis.TopToDown)
                {
                    body.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                else
                {
                    body.transform.rotation = Quaternion.Inverse(body.transform.rotation);
                }

                currentState = DirectionState.MovingForward;
                moveTime = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        anim.SetBool("IsDead", true);
        transform.GetComponent<CircleCollider2D>().enabled = false;

        destroyed = true;

        Destroy(gameObject, 1f);
        levelGenerator.enemies[0].enemiesCount--;
        levelGenerator.enemyKilledCount++;
        levelGenerator.score += score;
        levelGenerator.totalEnemies++;
    }
}