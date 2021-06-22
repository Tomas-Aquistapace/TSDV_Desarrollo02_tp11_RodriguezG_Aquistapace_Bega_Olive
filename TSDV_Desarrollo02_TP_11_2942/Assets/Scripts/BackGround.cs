using System;
using UnityEngine;
public class BackGround : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float limitY;
    [SerializeField] private float respawnY;
    private LevelGenerator levelGenerator;

    private void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }

    void Update()
    {
        if (levelGenerator.onGame)
        {
            transform.position -= Vector3.down * (velocity * Time.deltaTime);
            if (transform.position.y <= limitY)
                transform.position = new Vector3(0, respawnY, 10);
        }
    }
}