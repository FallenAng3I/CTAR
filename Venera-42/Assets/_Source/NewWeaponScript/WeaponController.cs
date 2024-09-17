using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon currentWeapon;
    public float fireRate = 0.5f; // Интервал между выстрелами
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            if (Time.time >= nextFireTime)
            {
                currentWeapon.Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    public void SetCurrentWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }
}