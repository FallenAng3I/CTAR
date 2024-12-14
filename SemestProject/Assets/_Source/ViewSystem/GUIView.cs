using TMPro;
using UnityEngine;
using WeaponSystem;

namespace ViewSystem
{
    public class GUIView : MonoBehaviour
    {
        public TMP_Text ammoView;     // Отображение патронов в магазине
        public TMP_Text maxAmmoView;  // Отображение патронов в резерве 
        public Rifle weapon;

        private void Update()
        {
            if (weapon.enabled)
            {
                UpdateAmmoDisplay();
                SetAmmoDisplayActive(true);
            }
            else
            {
                SetAmmoDisplayActive(false);
            }
        }

        private void UpdateAmmoDisplay()
        {
            ammoView.text = "" + weapon.magazineAmmo;
            maxAmmoView.text = "" + weapon.reserveAmmo;
        }

        private void SetAmmoDisplayActive(bool isActive)
        {
            ammoView.gameObject.SetActive(isActive);
            maxAmmoView.gameObject.SetActive(isActive);
        }
    }
}