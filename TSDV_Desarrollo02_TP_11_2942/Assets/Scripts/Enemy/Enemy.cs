using UnityEngine;
public class Enemy : MonoBehaviour
{
    [Header("Limits of enemy")]
    [SerializeField] public float rightEdge;
    [SerializeField] public float leftEdge;
    [SerializeField] public float topEdge;
    [SerializeField] public float downEdge;
    public void SetEnemy(LevelGenerator.EnemyType enemyType)
    {
        switch (enemyType)
        {
            case LevelGenerator.EnemyType.Easy:
                gameObject.AddComponent<Enemy01>();
                break;
            case LevelGenerator.EnemyType.Normal:
                break;
        }
    }
}