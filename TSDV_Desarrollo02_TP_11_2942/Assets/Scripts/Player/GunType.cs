using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunType : MonoBehaviour, IcanShoot
{
    public enum Type
    {
        standarGun,
        machineGun,
        rocketLauncher,
        railgun
    };

    public Type type;

    public List<Transform> spawnPosBullet;
    public GameObject bulletType;

    public void ShootGun()
    {
        for(int i = 0; i < spawnPosBullet.Count; i++)
        {
            GameObject go = Instantiate(bulletType);
            go.transform.name = bulletType.transform.name + i.ToString();

            go.transform.position = spawnPosBullet[i].position;
        }        
    }
}
