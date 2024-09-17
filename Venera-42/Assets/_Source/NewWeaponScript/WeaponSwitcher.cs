using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private PlayerInventory inventory;
    private WeaponEquipper weaponEquipper;
    private WeaponController weaponController;

    private int currentWeaponIndex = 0;

    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        weaponEquipper = GetComponent<WeaponEquipper>();
        weaponController = GetComponent<WeaponController>();

        if (inventory.weapons.Count > 0)
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
        if (weaponIndex >= 0 && weaponIndex < inventory.weapons.Count)
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
        Weapon weaponToEquip = inventory.weapons[index];
        weaponEquipper.EquipWeapon(weaponToEquip);
        weaponController.SetCurrentWeapon(weaponToEquip);
    }
}