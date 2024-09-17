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
            EquipWeapon(newWeapon);
        }
    }

    public bool HasWeapon(Weapon weapon)
    {
        return weapons.Contains(weapon);
    }

    public void AddAmmo(Weapon weapon, int ammoAmount)
    {
        weapon.currentAmmo += ammoAmount; // Добавляем патроны
        Debug.Log(weapon.weaponName + " ammo added: " + ammoAmount);
    }

    public void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;

        // Привязываем модель оружия к игроку
        if (weaponModel != null)
        {
            Destroy(weaponModel); // Удаляем старую модель
        }

        weaponModel = Instantiate(weapon.modelPrefab, weaponHoldPoint.position, Quaternion.identity);
        weaponModel.transform.SetParent(weaponHoldPoint);

        Debug.Log("Weapon equipped: " + weapon.weaponName);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Shoot();
        }
    }
}