using UnityEngine;

namespace _Source.NewWeaponScript
{
    public abstract class AWeapon : WeaponInfo
    {
        public virtual void Shoot()
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
        public void Scope()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                scope = true;
            }
            else
            {
                scope = false;
            }
        }
    }
}