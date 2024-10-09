using _Source.NewWeaponScript;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public float moveDistance = -10f;
    public AWeapon weapon;
    public int ammoAmount = 10;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAndWeapons andWeapons = other.GetComponent<PlayerAndWeapons>();

            if (andWeapons.HasWeapon(weapon))
            {
                andWeapons.AddAmmo(weapon, ammoAmount);
            }
            else
            {
                andWeapons.PickupWeapon(weapon);
            }

            DontDestroyOnLoad(weapon);
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
    }
}