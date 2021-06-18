using UnityEngine;

public class RestoreEnergy : MonoBehaviour
{
    public int totalRestore = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.GetComponent<Player>().RestoreEnergy(totalRestore);

            Destroy(this.gameObject);
        }
    }
}
