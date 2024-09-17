using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    private PlayerInventory inventory;
    

    private int currentWeaponIndex = 0;

    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
      

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
        // Деактивируем текущую модель оружия
        if (inventory.weaponModel != null)
        {
            Destroy(inventory.weaponModel);  // Удаляем текущую модель оружия
        }

        Weapon1 weaponToEquip = inventory.weapons[index];

        // Экипируем новое оружие
        inventory.EquipWeapon(weaponToEquip);
        
    }
}