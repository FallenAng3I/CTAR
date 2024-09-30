using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public float moveDistance = -10f;
<<<<<<< HEAD
    public Weapon weapon; // Ссылка на ScriptableObject оружия
    public int ammoAmount = 10; // Количество патронов для данного оружия
=======
    public AWeapon1 weapon;
    public int ammoAmount = 10;
>>>>>>> 1e1960511945aef7cd522e5675092e6a791c9a92

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            
            if (inventory.HasWeapon(weapon))
            {
                inventory.AddAmmo(weapon, ammoAmount);
            }
            else
            {
                inventory.PickupWeapon(weapon);
            }

            DontDestroyOnLoad(weapon);
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}