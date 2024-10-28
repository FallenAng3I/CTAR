using System;
using PlayerSystem;
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

        public bool isScope = false;
        private bool _canShoot = false;
        private float _nextFireTime;
        
        private Camera _mainCamera;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform shootPivot;
        [SerializeField] private Player player;
        [SerializeField] private Bullet bullet;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        public void Shoot()
        {
            if (_canShoot == true)
            {
                if (Time.time >= _nextFireTime)
                {
                    _nextFireTime = Time.time + 1f / fireRate;
                    
                    GameObject projectile = Instantiate(bulletPrefab, shootPivot.position, shootPivot.rotation);
                    
                    //projectile.transform.Rotate(90, 0, 0);
                    
                    Rigidbody bulletRb = projectile.GetComponent<Rigidbody>();
                    bulletRb.velocity = projectile.transform.forward * bullet.speed;

                    Debug.Log("Стреляю!");
                }
            }
            else
            {
                Debug.Log("Не могу стрелять!");
            }
        }

        public void Reload()
        {
            Debug.Log("Перезаряжаю!");
        }

        public void Scope()
        {
            if (isScope == true)
            {
                _canShoot = true;
            }
            else
            {
                _canShoot = false;
            }
        }
    }
}