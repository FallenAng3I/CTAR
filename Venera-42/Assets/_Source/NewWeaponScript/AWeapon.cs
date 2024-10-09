using UnityEngine;

namespace _Source.NewWeaponScript
{
    public abstract class AWeapon : MonoBehaviour
    {
        public string weaponName; 
        public GameObject modelPrefab; 
        public int currentAmmo; 
        public GameObject projectile; 
        public float projectileSpeed; 
        private float nextFireTime; 
        public Transform shootPoint; 
        public PlayerAndWeapons andWeapons;
        public bool scope;

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