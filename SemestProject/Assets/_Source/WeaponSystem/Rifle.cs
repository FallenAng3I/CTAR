using System.Collections;
using UnityEngine;

namespace WeaponSystem
{
    public class Rifle : MonoBehaviour
    {
        [Header("AKS-74U Parameters")]
        public int damage;
        public float fireRate;
        public int magazineAmmo;
        public int maxMagazineAmmo;
        public int reserveAmmo;
        public int maxReserveAmmno;
        public float reloadTime;

        //public bool isScope = false;
        public bool canShoot;
        public bool isReloading;
        private float _nextFireTime;
        
        private Camera _mainCamera;
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
                //TODO Добавить звук пустой обоймы
                Debug.Log("Не могу стрелять!");
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