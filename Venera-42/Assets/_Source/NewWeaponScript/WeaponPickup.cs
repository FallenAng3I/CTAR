using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon; // Ссылка на ScriptableObject оружия
    public int ammoAmount = 10; // Количество патронов для данного оружия

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            
            if (inventory.HasWeapon(weapon))
            {
                // Если оружие уже есть, добавляем патроны
                inventory.AddAmmo(weapon, ammoAmount);
            }
            else
            {
                // Если оружия нет, добавляем его в инвентарь
                inventory.PickupWeapon(weapon);
            }

            // Удаляем префаб оружия с пола
            Destroy(gameObject);
        }
    }
}