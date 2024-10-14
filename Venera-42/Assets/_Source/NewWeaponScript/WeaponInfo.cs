using UnityEngine;

namespace _Source.NewWeaponScript
{
    public class WeaponInfo : MonoBehaviour
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
    }
}
