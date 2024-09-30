using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
<<<<<<< HEAD
    
    public List<Weapon> weapons = new List<Weapon>();
    public Weapon currentWeapon;
    public Transform weaponHoldPoint;
    public GameObject weaponModel;

    public void PickupWeapon(Weapon newWeapon)
=======
    public List<AWeapon1> weapons = new List<AWeapon1>();
    public AWeapon1 currentWeapon;
    public Transform weaponHoldPoint;
    public GameObject weaponModel;

    public void PickupWeapon(AWeapon1 newWeapon)
>>>>>>> 1e1960511945aef7cd522e5675092e6a791c9a92
    {
        weapons.Add(newWeapon);
        Debug.Log("Weapon picked up: " + newWeapon.weaponName);

        if (currentWeapon == null)
        {
            EquipWeapon(newWeapon);
        }
    }

<<<<<<< HEAD
    public bool HasWeapon(Weapon weapon)
=======
    public bool HasWeapon(AWeapon1 weapon)
>>>>>>> 1e1960511945aef7cd522e5675092e6a791c9a92
    {
        return weapons.Contains(weapon);
    }

<<<<<<< HEAD
    public void AddAmmo(Weapon weapon, int ammoAmount)
=======
    public void AddAmmo(AWeapon1 weapon, int ammoAmount)
>>>>>>> 1e1960511945aef7cd522e5675092e6a791c9a92
    {
        weapon.currentAmmo += ammoAmount;
        Debug.Log(weapon.weaponName + " ammo added: " + ammoAmount);
    }

<<<<<<< HEAD
    public void EquipWeapon(Weapon weapon)
=======
    public void EquipWeapon(AWeapon1 weapon)
>>>>>>> 1e1960511945aef7cd522e5675092e6a791c9a92
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