using UnityEngine;

public abstract class AWeapon1 : MonoBehaviour
{
    public string weaponName; 
    public GameObject modelPrefab; 
    public int currentAmmo; 
    public GameObject projectile; 
    public float projectileSpeed; 
    private float nextFireTime; 
    public Transform shootPoint; 
    public PlayerInventory inventory;
    public bool scope;
    public abstract void Shoot();
    public void Scope()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            scope = true;
        }
        else
        {
            scope = false;
        }
    }
}