using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<AWeapon1> weapons = new List<AWeapon1>();
    public AWeapon1 currentWeapon;
    public Transform weaponHoldPoint;
    public GameObject weaponModel;

    public void PickupWeapon(AWeapon1 newWeapon)
    {
        weapons.Add(newWeapon);
        Debug.Log("Weapon picked up: " + newWeapon.weaponName);

        if (currentWeapon == null)
        {
            EquipWeapon(newWeapon);
        }
    }

    public bool HasWeapon(AWeapon1 weapon)
    {
        return weapons.Contains(weapon);
    }

    public void AddAmmo(AWeapon1 weapon, int ammoAmount)
    {
        weapon.currentAmmo += ammoAmount;
        Debug.Log(weapon.weaponName + " ammo added: " + ammoAmount);
    }

    public void EquipWeapon(AWeapon1 weapon)
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