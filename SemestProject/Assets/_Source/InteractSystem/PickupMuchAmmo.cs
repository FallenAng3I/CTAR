using UnityEngine;
using WeaponSystem;

namespace InteractSystem
{
    public class PickupMuchAmmo : MonoBehaviour, IInteractable
    {
        public int ammoToAdd = 30;   //Сколько патронов мы будем получать при повторном подборе оружия.

        public Rifle rifle;

        public void Interact()
        {
            if (rifle.maxReserveAmmo > 0)
            {
                var newReserveAmmo = Mathf.Clamp(rifle.reserveAmmo + ammoToAdd, 0, rifle.maxReserveAmmo);
                rifle.reserveAmmo = newReserveAmmo;
            }
        }
    }
}
