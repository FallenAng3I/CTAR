using UnityEngine;
using System.Collections.Generic;
using WeaponSystem;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        public Transform weaponPivot;
        [SerializeField] private List<AWeapon> inventory = new List<AWeapon>(); // Инвентарь игрока
        private int currentWeaponIndex = -1; // Индекс текущего оружия в инвентаре
        
        private AWeapon currentWeapon; // Текущее оружие в руках

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchWeapon(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchWeapon(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchWeapon(2);
            }

            // Стрельба, если текущее оружие не пустое
            if (Input.GetButtonDown("Fire1") && currentWeaponIndex >= 0)
            {
                inventory[currentWeaponIndex].Shoot();
            }
        }

        public void PickupWeapon(AWeapon weapon)
        {
            Debug.Log("Picking up weapon: " + weapon.weaponName);
            inventory.Add(weapon); // Добавляем оружие в инвентарь

            // Если у игрока еще нет оружия, можем назначить его текущим
            if (currentWeapon == null)
            {
                currentWeapon = weapon;
                weapon.ShowWeapon(true); // Показываем модель оружия на игроке
            }
        }

        private void SwitchWeapon(int index)
        {
            if (index >= 0 && index < inventory.Count)
            {
                // Скрываем текущее оружие
                if (currentWeaponIndex >= 0)
                {
                    inventory[currentWeaponIndex].ShowWeapon(false);
                }

                currentWeaponIndex = index; // Переключаем на новое оружие
                inventory[currentWeaponIndex].ShowWeapon(true); // Показываем новое оружие
            }
        }
    }
}
