using System.Collections;
using UnityEngine;

namespace WeaponSystem
{
    public class Rifle : MonoBehaviour
    {
        [Header("AKS-74U Config")]
        public int damage;              // Урон                         
        public float fireRate;          // Скорострельность             
        public int magazineAmmo;        // Число патронов в магазине    
        public int maxMagazineAmmo;     // Максимум патронов в магазине 
        public int reserveAmmo;         // Число патронов в резерве     
        public int maxReserveAmmno;     // Максимум патронов в резерве  
        public float reloadTime;        // Скорость перезарядки         
        
        public bool canShoot;
        public bool isReloading;
        private float _nextFireTime;
        
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform shootPivot;
        [SerializeField] private Bullet bullet;

        public void Start()
        {
        }

        public void Shoot()
        {
            if (canShoot && magazineAmmo > 0 && !isReloading)
            {
                if (Time.time >= _nextFireTime)
                { 
                    _nextFireTime = Time.time + 1f / fireRate;
                    
                    GameObject projectile = Instantiate(bulletPrefab, shootPivot.position, shootPivot.rotation);
                    
                    Bullet bulletComponent = projectile.GetComponent<Bullet>();
                    bulletComponent.damage = damage; // Передача значения урона от оружия в пулю
                    
                    Rigidbody bulletRb = projectile.GetComponent<Rigidbody>();
                    bulletRb.velocity = projectile.transform.forward * bullet.speed;

                    magazineAmmo--;
                }
            }
            else
            {
                // Звук пустой обоймы
            }
        }

        public void Reload()
        {
            if (isReloading || magazineAmmo == maxMagazineAmmo) return;

            StartCoroutine(ReloadCoroutine());
        }
        private IEnumerator ReloadCoroutine()
        {
            isReloading = true;

            yield return new WaitForSeconds(reloadTime);

            int neededAmmo = maxMagazineAmmo - magazineAmmo;
            int ammoToReload = Mathf.Min(neededAmmo, reserveAmmo);

            magazineAmmo += ammoToReload;
            reserveAmmo -= ammoToReload;

            isReloading = false;
        }
    }
}