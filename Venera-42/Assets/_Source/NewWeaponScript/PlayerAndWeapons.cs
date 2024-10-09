using System.Collections.Generic;
using UnityEngine;

namespace _Source.NewWeaponScript
{
    public class PlayerAndWeapons : MonoBehaviour //Класс нужен для логики взаимодействия игрока и его орудий
    {
        public List<AWeapon> weapons = new List<AWeapon>();
        public AWeapon currentWeapon;
        public Transform weaponHoldPoint;
        public GameObject weaponModel;

        public void PickupWeapon(AWeapon newWeapon)
        {
            weapons.Add(newWeapon);
            Debug.Log("Weapon picked up: " + newWeapon.weaponName);

            if (currentWeapon == null)
            {
                EquipWeapon(newWeapon);
            }
        }

        public bool HasWeapon(AWeapon weapon)
        {
            return weapons.Contains(weapon);
        }

        public void AddAmmo(AWeapon weapon, int ammoAmount)
        {
            weapon.currentAmmo += ammoAmount;
            Debug.Log(weapon.weaponName + " ammo added: " + ammoAmount);
        }

        public void EquipWeapon(AWeapon weapon)
        {
            if (weaponModel != null)
            {
                Destroy(weaponModel);
                weaponModel = null;
            }

            if (weapons.Contains(weapon))
            {
                currentWeapon = weapon;

                weaponModel = Instantiate(weapon.modelPrefab, weaponHoldPoint.position, weaponHoldPoint.rotation);
                weaponModel.transform.SetParent(weaponHoldPoint);

                weaponModel.transform.localRotation = Quaternion.identity;
                weaponModel.transform.localPosition = Vector3.zero;

                Debug.Log("Weapon equipped: " + weapon.weaponName);
            }
        }

        //TODO Спросить как перенести этот скрипт и стоит ли
        void Update()
        {
            //это лучшее что я смог придумать
            if (currentWeapon != null)
            {
                currentWeapon.Scope();
                if (Input.GetButtonDown("Fire1") && currentWeapon.scope)
                {
                    currentWeapon.Shoot();
                }
            }
        }
    }
}