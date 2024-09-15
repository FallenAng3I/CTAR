using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public float damage;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public Object modelPrefab;


    public abstract void Shoot();
}
