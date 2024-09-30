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