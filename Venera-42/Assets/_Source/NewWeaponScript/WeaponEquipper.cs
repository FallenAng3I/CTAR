using UnityEngine;

public class WeaponEquipper : MonoBehaviour
{
    public Transform weaponHoldPoint;
    private GameObject weaponModel;

    public void EquipWeapon(Weapon weapon)
    {
        if (weaponModel != null)
        {
            Destroy(weaponModel);
        }

        weaponModel = Instantiate(weapon.modelPrefab, weaponHoldPoint.position, weaponHoldPoint.rotation);
        weaponModel.transform.SetParent(weaponHoldPoint);
        
        Debug.Log("Weapon equipped: " + weapon.weaponName);
    }

}