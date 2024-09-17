using UnityEngine;

[CreateAssetMenu(fileName = "Pistol", menuName = "Gurza")]
public class Pistol : Weapon
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
