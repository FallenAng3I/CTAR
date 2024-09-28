using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public float moveDistance = -10f;
    public AWeapon1 weapon;
    public int ammoAmount = 10;

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