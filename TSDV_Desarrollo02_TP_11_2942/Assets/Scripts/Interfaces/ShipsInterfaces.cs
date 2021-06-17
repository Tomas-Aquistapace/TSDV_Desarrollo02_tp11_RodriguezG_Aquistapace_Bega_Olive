using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ikillable
{
    bool Killable(int value);
}

public interface ItakeDamage
{
    void TakeDamage(int damage);
}

public interface IcanShoot
{
    void ShootGun();
}
