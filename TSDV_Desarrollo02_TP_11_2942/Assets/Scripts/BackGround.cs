using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private float velocity;
    
    void Update()
    {
        transform.position -= Vector3.down * (velocity * Time.deltaTime);
    }
}
