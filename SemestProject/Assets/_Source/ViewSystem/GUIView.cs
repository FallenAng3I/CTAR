using TMPro;
using UnityEngine;
using WeaponSystem;

namespace ViewSystem
{
    public class GUIView : MonoBehaviour
    {
        public GameObject weapon;
        public GameObject ammoImage;
        public TMP_Text ammoView;     // Отображение патронов в магазине
        public TMP_Text maxAmmoView;  // Отображение патронов в резерве 
        public Rifle rifle;

        private void Update()
        {
            if (rifle.enabled)
            {
                weapon.SetActive(true);
                ammoImage.SetActive(true);
                UpdateAmmoDisplay();
                SetAmmoDisplayActive(true);
            }
            else
            {
                weapon.SetActive(false);
                SetAmmoDisplayActive(false);
            }
        }

        private void UpdateAmmoDisplay()
        {
            ammoView.text = "" + rifle.magazineAmmo;
            maxAmmoView.text = "" + rifle.reserveAmmo;
        }

        private void SetAmmoDisplayActive(bool isActive)
        {
            ammoView.gameObject.SetActive(isActive);
            maxAmmoView.gameObject.SetActive(isActive);
        }
    }
}