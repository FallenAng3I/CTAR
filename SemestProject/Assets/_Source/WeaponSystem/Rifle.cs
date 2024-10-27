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
        
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject shootPivot;

        public void Shoot()
        {
            Debug.Log("Стреляю!");
        }

        public void Reload()
        {
            Debug.Log("Перезаряжаю!");
        }

        public void Update()
        {
            
        }
    }
}