using UnityEngine;
public class BackGround : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float limitY;
    [SerializeField] private float respawnY;
    void Update()
    {
        transform.position -= Vector3.down * (velocity * Time.deltaTime);
        if (transform.position.y <= limitY) 
            transform.position = new Vector3(0, respawnY, 10);
    }
}