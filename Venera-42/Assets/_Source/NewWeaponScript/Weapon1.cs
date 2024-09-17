using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon1 : MonoBehaviour
{
    
    public string weaponName; //Имя
    public GameObject modelPrefab; //Модель
    public int currentAmmo; // Текущие патроны
    public int maxAmmo;     // Максимальные патроны для этого оружия
    public GameObject projectile; //пуля
    public float projectileSpeed;// скорость пули
    public float fireRate ; // Интервал между выстрелами
    private float nextFireTime ;// интервал
    public Transform shootPoint;//точка для пули
    public PlayerInventory inventory;

    public abstract void Shoot();
}
