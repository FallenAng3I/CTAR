using TMPro;
using UnityEngine;
using WeaponSystem;

namespace ViewSystem
{
    public class GUIView : MonoBehaviour
    {
        public TMP_Text ammoView;
        public TMP_Text maxAmmoView;

        public Rifle weapon;
        
        public void UpdateAmmoDisplay()
        {
            ammoView.text = " " + weapon.magazineAmmo.ToString();
            maxAmmoView.text = " " + weapon.reserveAmmo.ToString();
        }
    }
}
