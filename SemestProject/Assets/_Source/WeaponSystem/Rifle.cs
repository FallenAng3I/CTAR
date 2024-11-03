using System.Collections;
using PlayerSystem;
using UnityEngine;
using ViewSystem;

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
        public bool canShoot = false;
        public bool isReloading = false;
        private float _nextFireTime;
        private float _originalSpeed;
        
        private Camera _mainCamera;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform shootPivot;
        [SerializeField] private Player player;
        [SerializeField] private Bullet bullet;
        [SerializeField] private GUIView gui;

        public void Start()
        {
            _originalSpeed = player.speed;
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
                    bulletComponent.damage = this.damage; // Передача значения урона от оружия в пулю
                    
                    Rigidbody bulletRb = projectile.GetComponent<Rigidbody>();
                    bulletRb.velocity = projectile.transform.forward * bullet.speed;

                    magazineAmmo--;
                    gui.UpdateAmmoDisplay();
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

            gui.UpdateAmmoDisplay();

            isReloading = false;
        }
        
        public void Scope()
        {
            
        }
    }
}