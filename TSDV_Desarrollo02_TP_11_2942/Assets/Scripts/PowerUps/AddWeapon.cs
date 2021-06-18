using UnityEngine;

public class AddWeapon : MonoBehaviour
{
    public enum TypeofGun
    {
        machineGun,
        rocketLauncher,
        railgun
    };
    public TypeofGun type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            switch (type)
            {
                case TypeofGun.machineGun:
                    collision.GetComponent<Player>().machineGun.SetActive(true);

                    break;
                case TypeofGun.rocketLauncher:
                    collision.GetComponent<Player>().rocketLauncher.SetActive(true);

                    break;
                case TypeofGun.railgun:
                    collision.GetComponent<Player>().railgun.SetActive(true);

                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
