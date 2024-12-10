using System;
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
            UpdateAmmoDisplay();
        }

        public void UpdateAmmoDisplay()
        {
            ammoView.text = " " + weapon.magazineAmmo.ToString();
            maxAmmoView.text = " " + weapon.reserveAmmo.ToString();
        }
    }
}
