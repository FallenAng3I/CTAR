using UnityEngine;

<<<<<<< HEAD
public class ShotGun : Weapon
=======
public class ShotGun : AWeapon1
>>>>>>> 1e1960511945aef7cd522e5675092e6a791c9a92
{
    public override void Shoot()
    {
        if (inventory.currentWeapon.currentAmmo > 0)
        {
            GameObject newProjectile = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            rb.velocity = shootPoint.forward * projectileSpeed;
            Debug.Log("Firing " + inventory.currentWeapon.weaponName);
            inventory.currentWeapon.currentAmmo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
