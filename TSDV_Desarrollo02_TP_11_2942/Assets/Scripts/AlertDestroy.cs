using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.LogError("Un objeto pasó el límite: " + other.gameObject.name + " Contra: " + gameObject.name);
        Destroy(other.gameObject);
    }
}
