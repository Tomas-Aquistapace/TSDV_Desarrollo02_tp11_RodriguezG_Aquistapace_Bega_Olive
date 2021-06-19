using System;
using UnityEngine;

public class Enemy01 : Enemy
{
    public enum State
    {
        MovingForward,
        MovingBack
    }
    State _currentState;
    float _speed = 10;
    Vector3 _direction;
    void OnEnable()
    {
        _currentState = State.MovingForward;
        _direction = GetDirection();
    }
    void OnDisable()
    {

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
        if (_currentState == State.MovingForward)
        {
            if (_direction == Vector3.right) return transform.position.x >= rightEdge;
            if (_direction == Vector3.left) return transform.position.x <= leftEdge;
            if (_direction == Vector3.down) return transform.position.y <= downEdge;
            if (_direction == Vector3.up) return transform.position.y >= topEdge;
        }
        else
        {
            if (_direction == Vector3.right) return !(transform.position.x >= leftEdge);
            if (_direction == Vector3.left) return !(transform.position.x <= rightEdge);
            if (_direction == Vector3.down) return transform.position.y >= topEdge;
            if (_direction == Vector3.up) return !(transform.position.y >= downEdge);
        }
        return true;
    }
}