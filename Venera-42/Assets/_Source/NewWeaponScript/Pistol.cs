using UnityEngine;

<<<<<<< HEAD:Venera-42/Assets/_Source/NewWeaponScript/Pistol.cs
public class Pistol : Weapon
=======
public class Pistol1 : AWeapon1
>>>>>>> 1e1960511945aef7cd522e5675092e6a791c9a92:Venera-42/Assets/_Source/NewWeaponScript/Pistol1.cs
{
    public override void Shoot()
    {
        if (inventory.currentWeapon.currentAmmo > 0 && scope)
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
