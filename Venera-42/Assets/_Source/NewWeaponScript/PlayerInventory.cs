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
        // Проверяем и уничтожаем предыдущую модель оружия, если она существует
        if (weaponModel != null)
        {
            Destroy(weaponModel);
            weaponModel = null;  // Обязательно обнуляем ссылку на старую модель
        }

        // Проверяем, что оружие есть в инвентаре
        if (weapons.Contains(weapon))
        {
            currentWeapon = weapon;

            // Создаём новую модель оружия и помещаем её в точку для оружия
            weaponModel = Instantiate(weapon.modelPrefab, weaponHoldPoint.position, weaponHoldPoint.rotation);
            weaponModel.transform.SetParent(weaponHoldPoint);

            // Убедимся, что модель правильно ориентирована
            weaponModel.transform.localRotation = Quaternion.identity;
            weaponModel.transform.localPosition = Vector3.zero;

            Debug.Log("Weapon equipped: " + weapon.weaponName);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Shoot();
        }
    }
}