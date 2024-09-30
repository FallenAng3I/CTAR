using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    
    public string weaponName; 
    public GameObject modelPrefab; 
    public int currentAmmo; 
    public int maxAmmo;     
    public GameObject projectile; 
    public float projectileSpeed;
    public float fireRate ; 
    private float nextFireTime ;
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
