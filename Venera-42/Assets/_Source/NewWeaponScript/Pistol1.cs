using UnityEngine;

public class Pistol1 : AWeapon1
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