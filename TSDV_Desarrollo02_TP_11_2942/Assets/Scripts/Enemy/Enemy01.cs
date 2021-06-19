using System.Collections;
using UnityEngine;
public class Enemy01 : MonoBehaviour, ItakeDamage, Ikillable
{
    [Header("Enemy Gun")]
    public GameObject gun;
    enum State
    {
        MovingForward,
        MovingBack
    }
    State _currentState;
    float _speed = 10;
    Vector3 _direction;
    Enemy _enemy;
    float _time;
    int _energy = 10;
    void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        _currentState = State.MovingForward;
        _direction = GetDirection();
    }
    void OnDisable()
    {

    }
    void Update()
    {
        _time += Time.deltaTime;
        if (_time < 1) return;
        gun.GetComponent<IcanShoot>().ShootGun();
        _time = 0;
    }
    void FixedUpdate()
    {
        switch (_currentState)
        {
            case State.MovingForward:
                transform.Translate(_direction * _speed * Time.deltaTime);
                if (ChangeDirection()) _currentState = State.MovingBack;
                break;
            case State.MovingBack:
                transform.Translate(-_direction * _speed * Time.deltaTime);
                if (ChangeDirection()) _currentState = State.MovingForward;
                break;
            default:
                break;
        }
    }
    Vector3 GetDirection()
    {
        if (transform.position.x < _enemy.leftEdge)
            return Vector3.right;
        if (transform.position.x > _enemy.rightEdge)
            return Vector3.left;
        if (transform.position.y > _enemy.topEdge)
            return Vector3.down;
        if (transform.position.y < _enemy.downEdge)
            return Vector3.up;
        return Vector3.zero;
    }
    bool ChangeDirection()
    {
        if (_currentState == State.MovingForward)
        {
            if (_direction == Vector3.right) return transform.position.x >= _enemy.rightEdge;
            if (_direction == Vector3.left) return transform.position.x <= _enemy.leftEdge;
            if (_direction == Vector3.down) return transform.position.y <= _enemy.downEdge;
            if (_direction == Vector3.up) return transform.position.y >= _enemy.topEdge;
        }
        else
        {
            if (_direction == Vector3.right) return !(transform.position.x >= _enemy.leftEdge);
            if (_direction == Vector3.left) return !(transform.position.x <= _enemy.rightEdge);
            if (_direction == Vector3.down) return transform.position.y >= _enemy.topEdge;
            if (_direction == Vector3.up) return !(transform.position.y >= _enemy.downEdge);
        }
        return true;
    }

    public void TakeDamage(int damage)
    {
        _energy -= damage;

        if (Killable(_energy))
            Destroy(gameObject);
    }

    public bool Killable(int value)
    {
        return value <= 0;
    }
}