using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum CollitionType
    {
        common,
        explosion,
        pierse
    };
    public CollitionType collitionType;

    public int damage = 10;
    public float speed;
    [SerializeField]
    float timeToDestroy = 2f;

    Rigidbody2D rig;

    private void Start()
    {
        rig = transform.GetComponent<Rigidbody2D>();
        rig.velocity = transform.up * speed;

        Destroy(this.gameObject, timeToDestroy);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {        
        collision.GetComponent<ItakeDamage>().TakeDamage(damage);

        switch (collitionType)
        {
            case CollitionType.common:
                Destroy(this.gameObject);
                break;

            case CollitionType.explosion:
                Destroy(this.gameObject);
                break;

            case CollitionType.pierse:

                break;
        }
    }
}