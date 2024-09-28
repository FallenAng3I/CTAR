using UnityEngine;

public abstract class AWeapon1 : MonoBehaviour
{
    public string weaponName;       //Имя
    public GameObject modelPrefab;  //Модель
    public int currentAmmo;         //Текущие патроны
    public int maxAmmo;             //Максимальные патроны для этого оружия
    public GameObject projectile;   //Пуля
    public float projectileSpeed;   //Скорость пули

    private float nextFireTime;     //Интервал
    public Transform shootPoint;    //Точка для пули
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
