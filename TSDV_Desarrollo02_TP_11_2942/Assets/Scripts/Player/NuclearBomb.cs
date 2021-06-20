using UnityEngine;

public class NuclearBomb : MonoBehaviour
{
    public float timeToDelete = 2f;

    void Start()
    {
        DestroyAllEnemies();

        Destroy(this.gameObject, timeToDelete);
    }

    void DestroyAllEnemies()
    {

    }

}
