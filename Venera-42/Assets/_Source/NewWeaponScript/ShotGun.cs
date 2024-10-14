using UnityEngine;

namespace _Source.NewWeaponScript
{
    public class ShotGun : AWeapon
    {
        [SerializeField] private int shotgunSpread;
        [SerializeField] private int shotgunPelletCount;
        public override void Shoot()
        {
            if (andWeapons.currentWeapon.currentAmmo > 0)
            {
                for (int i = 0; i < shotgunPelletCount; i++)
                {
                    GameObject newPellet = Instantiate(projectile, shootPoint.position, Random.rotation);
                    Rigidbody rb = newPellet.GetComponent<Rigidbody>();
                    Vector3 spread = new Vector3(Random.Range(-shotgunSpread, shotgunSpread), 0, 0);
                    Vector3 direction = shootPoint.forward + spread;
                    rb.velocity = direction.normalized * projectileSpeed;
                }
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