using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    
    public List<Weapon1> weapons = new List<Weapon1>();
    public Weapon1 currentWeapon;
    public Transform weaponHoldPoint;
    public GameObject weaponModel;

    public void PickupWeapon(Weapon1 newWeapon)
    {
        weapons.Add(newWeapon);
        Debug.Log("Weapon picked up: " + newWeapon.weaponName);

        if (currentWeapon == null)
        {
            EquipWeapon(newWeapon);
        }
    }

    public bool HasWeapon(Weapon1 weapon)
    {
        return weapons.Contains(weapon);
    }

    public void AddAmmo(Weapon1 weapon, int ammoAmount)
    {
        weapon.currentAmmo += ammoAmount; // Добавляем патроны
        Debug.Log(weapon.weaponName + " ammo added: " + ammoAmount);
    }

    public void EquipWeapon(Weapon1 weapon)
    {
        // уничтожаем предыдущую модель оружия
        if (weaponModel != null)
        {
            Destroy(weaponModel);
            weaponModel = null;  // обнуляем ссылку на старую модель
        }

        // оружие есть в инвентаре
        if (weapons.Contains(weapon))
        {
            currentWeapon = weapon;

            // Создаём новую модель оружия 
            weaponModel = Instantiate(weapon.modelPrefab, weaponHoldPoint.position, weaponHoldPoint.rotation);
            weaponModel.transform.SetParent(weaponHoldPoint);
            

            // модель правильно ориентирована
            weaponModel.transform.localRotation = Quaternion.identity;
            weaponModel.transform.localPosition = Vector3.zero;

            Debug.Log("Weapon equipped: " + weapon.weaponName);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentWeapon != null && currentWeapon.scope ) 
        {
            currentWeapon.Shoot();
        }

        if (currentWeapon != null)
        {
            currentWeapon.Scope();
        }
    }
}