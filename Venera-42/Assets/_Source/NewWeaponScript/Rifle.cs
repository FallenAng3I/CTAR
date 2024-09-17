using UnityEngine;

[CreateAssetMenu(fileName = "Rifle", menuName = "AK747")]
public class Rifle : Weapon
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