using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun  : Weapon
{
public override void Shoot()
{
    GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
    Rigidbody rb = projectile.GetComponent<Rigidbody>();
    rb.velocity = shootPoint.forward * 1f; // Установите нужную скорость
}
}
