using System;
using UnityEngine;

namespace WeaponSystem
{
    public class Rifle : AWeapon
    {
        public GameObject bulletPrefab;

        protected override void FireBullet()
        {
            if (bulletPrefab != null && firePoint != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                
                Bullet bulletComponent = bullet.GetComponent<Bullet>();
                if (bulletComponent != null)
                {
                    bulletComponent.Initialize(damage);
                }
        
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = firePoint.forward * 50f;
                }
            }
        }
    }
}