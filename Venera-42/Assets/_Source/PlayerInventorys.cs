using UnityEngine;
using System.Collections.Generic;

public class PlayerInventorys : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    public Weapon currentWeapon;
    public Transform weaponHoldPoint;
    public GameObject weaponModel;

    public void PickupWeapon(Weapon newWeapon)
    {
        // Добавляем новое оружие в инвентарь
        weapons.Add(newWeapon);
        Debug.Log("Weapon picked up: " + newWeapon.weaponName);

        // Если у игрока нет текущего оружия, сразу его экипируем
        if (currentWeapon == null)
        {
            EquipWeapon(newWeapon);
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        // Если оружие есть в инвентаре
        if (weapons.Contains(weapon))
        {
            currentWeapon = weapon;

            // Если уже есть визуальная модель, уничтожаем её перед заменой
            if (weaponModel != null)
            {
                Destroy(weaponModel);
            }

            // Создаём визуальную модель оружия на месте у игрока
            // Явно приводим Instantiate к типу GameObject
            weaponModel = (GameObject)Instantiate(weapon.modelPrefab, weaponHoldPoint.position, Quaternion.identity);

            if (weaponModel != null)
            {
                weaponModel.transform.SetParent(weaponHoldPoint);
            }
        
            Debug.Log("Weapon equipped: " + weapon.weaponName);
        }
        else
        {
            Debug.Log("Weapon not in inventory: " + weapon.weaponName);
        }
    }

    void Update()
    {
        // Логика стрельбы по нажатию кнопки
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Shoot();
        }

        // Логика для переключения оружия (например, по клавишам 1, 2, 3 и т.д.)
    }
}