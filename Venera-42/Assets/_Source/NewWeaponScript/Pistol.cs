using UnityEngine;

namespace _Source.NewWeaponScript
{
    public class Pistol : AWeapon
    {
        public override void Shoot()
        {
            if (andWeapons.currentWeapon.currentAmmo > 0)
            {
                GameObject newProjectile = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
                Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
                rb.velocity = shootPoint.forward * projectileSpeed;
                Debug.Log("Firing " + andWeapons.currentWeapon.weaponName);
                andWeapons.currentWeapon.currentAmmo--;
            }
            else
            {
                Debug.Log("Out of ammo!");
            }
        }
    }
}