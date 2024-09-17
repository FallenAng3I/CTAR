using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public float moveDistance = -10f;
    public Weapon1 weapon; // Ссылка на ScriptableObject оружия
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
            
            DontDestroyOnLoad(weapon);
            Vector3 newPosition = new Vector3(other.transform.position.x, other.transform.position.y + moveDistance, other.transform.position.z);
            other.transform.position = newPosition; // Перемещение объекта
            
        }
    }
}