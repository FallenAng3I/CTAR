using UnityEngine;
using WeaponSystem;

namespace InteractSystem
{
    public class PickupWeapon : MonoBehaviour
    {
        public int ammoToAdd = 20;   //Сколько патронов мы будем получать при повторном подборе оружия.

        public Rifle rifle;
        public GameObject weaponView;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            
            if (rifle.enabled == false)
            {
                rifle.enabled = true;
                weaponView.gameObject.SetActive(true);
            }
            else// if (rifle.enabled)
            {
                if (rifle.maxReserveAmmo > 0)
                {
                    var newReserveAmmo = Mathf.Clamp(rifle.reserveAmmo + ammoToAdd, 0, rifle.maxReserveAmmo);
                    rifle.reserveAmmo = newReserveAmmo;
                }
            }
                
            Destroy(gameObject);
        }
    }
}