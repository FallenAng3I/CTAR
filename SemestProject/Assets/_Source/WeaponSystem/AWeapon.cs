using UnityEngine;

namespace WeaponSystem
{
    public abstract class AWeapon : MonoBehaviour
    {
        public string weaponName;       // Название оружия
        public int damage;              // Урон
        public float fireRate;          // Скорострельность
        public int maxMagazineAmmo;     // Вместимость магазина
        public int currentMagazineAmmo; // Текущие патроны в магазине
        public int reserveAmmo;         // Патроны в запасе
        public int maxReserveAmmo;      // Максимальный запас патронов

        private float lastShotTime;     // Время последнего выстрела

        public GameObject weaponModel;  // Модель оружия, которая будет отображаться на игроке
        public Transform firePoint;     // Точка, из которой будут вылетать пули

        private Camera _playerCamera;     // Камера игрока для получения позиции курсора
        public LayerMask aimLayerMask;    // Маска слоя, на котором можно прицеливаться (например, земля)
        
        void Start()
        {
            _playerCamera = Camera.main;
        }
        
        public virtual void Shoot()
        {
            
        }

        protected virtual void FireBullet()
        {
        }
        
        public void AimAtCursor()
        {
            Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, aimLayerMask))
            {
                Vector3 targetPoint = hit.point;
                Vector3 directionToTarget = (targetPoint - firePoint.position).normalized;
                
                firePoint.forward = directionToTarget;
            }
        }
        
        public void Reload()
        {
            if (reserveAmmo > 0 && currentMagazineAmmo < maxMagazineAmmo)
            {
                int neededAmmo = maxMagazineAmmo - currentMagazineAmmo;

                if (reserveAmmo >= neededAmmo)
                {
                    currentMagazineAmmo += neededAmmo;
                    reserveAmmo -= neededAmmo;
                }
                else
                {
                    currentMagazineAmmo += reserveAmmo;
                    reserveAmmo = 0;
                }
            }
        }
        
        protected bool CanShoot()
        {
            return Time.time >= lastShotTime + (1f / fireRate) && currentMagazineAmmo > 0;
        }
        
        public void ShowWeapon(bool show)
        {
            if (weaponModel != null)
            {
                weaponModel.SetActive(show);
            }
        }
        
        void Update()
        {
            AimAtCursor();
        }
    }
}
