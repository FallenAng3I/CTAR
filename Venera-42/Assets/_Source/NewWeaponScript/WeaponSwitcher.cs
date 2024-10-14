using _Source.NewWeaponScript;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerAndWeapons _andWeapons;
    [SerializeField] private int currentWeaponIndex = 0;
    void Start()
    {
        _andWeapons = GetComponent<PlayerAndWeapons>();
        
        if (_andWeapons.weapons.Count > 0)
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
        if (weaponIndex >= 0 && weaponIndex < _andWeapons.weapons.Count)
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
        if (_andWeapons.weaponModel != null)
        {
            Destroy(_andWeapons.weaponModel);
        }
        
        AWeapon weaponToEquip = _andWeapons.weapons[index];
        _andWeapons.EquipWeapon(weaponToEquip);
    }
}