using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    public Weapon currentWeapon;
    public Transform weaponHoldPoint;
    public GameObject weaponModel;
    public void PickupWeapon(Weapon newWeapon)
    {
        weapons.Add(newWeapon);
        Debug.Log("Weapon picked up: " + newWeapon.weaponName);
        if (currentWeapon == null)
        {
            Debug.Log("Equipping weapon: " + newWeapon.weaponName);
            EquipWeapon(newWeapon);
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (weapons.Contains(weapon))
        {
            currentWeapon = weapon;

            // Привязываем визуальную модель к игроку
            
             weaponModel = (GameObject)Instantiate(weapon.modelPrefab, weaponHoldPoint.position, Quaternion.identity);
            weaponModel.transform.SetParent(weaponHoldPoint);
        
            // Здесь можно добавить дополнительную логику для анимаций
            // Например:
            // animator.SetTrigger("Equip");
        
            Debug.Log("Weapon equipped: " + weapon.weaponName);
            
        }
        else
        {
            Debug.Log("Weapon not in inventory: " + weapon.weaponName);
        }
       
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Shoot();
        }

        // Логика для переключения оружия (например, с помощью клавиш 1, 2, 3 и т.д.)
    }
}
