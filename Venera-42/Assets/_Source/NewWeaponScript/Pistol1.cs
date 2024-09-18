using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol1 : Weapon1
{
    
    public override void Shoot()
    {
        if (inventory.currentWeapon.currentAmmo > 0 && scope)
        {
            GameObject newProjectile = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            rb.velocity = shootPoint.forward * projectileSpeed; // Двигаем снаряд в направлении стрельбы
            Debug.Log("Firing " + inventory.currentWeapon.weaponName);
            inventory.currentWeapon.currentAmmo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
    
}
