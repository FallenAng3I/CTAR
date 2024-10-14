using UnityEngine;
using UnityEngine.Serialization;

namespace _Source.NewWeaponScript
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private PlayerAndWeapons andWeapons;
        [SerializeField] private int currentWeaponIndex = 0;
        void Start()
        {
            andWeapons = FindObjectOfType<PlayerAndWeapons>();
        
            if (andWeapons.weapons.Count > 0)
            {
                EquipWeaponAtIndex(currentWeaponIndex);
            }
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchWeapon(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchWeapon(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchWeapon(2);
        }
        void SwitchWeapon(int weaponIndex)
        {
            if (weaponIndex >= 0 && weaponIndex < andWeapons.weapons.Count)
            {
                currentWeaponIndex = weaponIndex;
                EquipWeaponAtIndex(currentWeaponIndex);
            }
            else
            {
                Debug.Log("No weapon in this slot.");
            }
        }
        void EquipWeaponAtIndex(int index)
        {
            if (andWeapons.weaponModel != null)
            {
                Destroy(andWeapons.weaponModel);
            }
        
            AWeapon weaponToEquip = andWeapons.weapons[index];
            andWeapons.EquipWeapon(weaponToEquip);
        }
    }
}