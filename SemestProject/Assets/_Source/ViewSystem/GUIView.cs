using TMPro;
using UnityEngine;
using WeaponSystem;

namespace ViewSystem
{
    public class GUIView : MonoBehaviour
    {
        public GameObject image;
        public TMP_Text ammoView;     // Отображение патронов в магазине
        public TMP_Text maxAmmoView;  // Отображение патронов в резерве 
        public Rifle weapon;

        private void Update()
        {
            if (weapon.enabled)
            {
                image.SetActive(true);
                UpdateAmmoDisplay();
                SetAmmoDisplayActive(true);
            }
            else
            {
                image.SetActive(false);
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