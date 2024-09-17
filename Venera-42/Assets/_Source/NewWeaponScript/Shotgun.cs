using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Berdanka")]
public class Shotgun : Weapon
{
    public override void Shoot()
    {
        if (currentAmmo > 0)
        {
            Debug.Log("Firing " + weaponName);
            currentAmmo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}