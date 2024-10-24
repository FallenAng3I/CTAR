using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class Inventory : MonoBehaviour
    {
        private List<AWeapon> weapons = new List<AWeapon>(); // Инвентарь для оружия

        public void AddWeapon(AWeapon weaponPrefab)
        {
            // Проверяем, есть ли уже это оружие в инвентаре
            AWeapon existingWeapon = weapons.Find(w => w.weaponName == weaponPrefab.weaponName);
            
            if (existingWeapon != null)
            {
                // Если оружие уже есть, добавляем патроны
                existingWeapon.reserveAmmo += weaponPrefab.reserveAmmo; // Добавляем патроны
                Debug.Log("Ammo added to existing weapon: " + existingWeapon.weaponName);
            }
            else
            {
                // Если оружия нет, создаем экземпляр и добавляем его в инвентарь
                AWeapon weaponInstance = Instantiate(weaponPrefab);
                weapons.Add(weaponInstance);
                weaponInstance.transform.SetParent(transform); // Привязываем к игроку
            }
        }
    }
}