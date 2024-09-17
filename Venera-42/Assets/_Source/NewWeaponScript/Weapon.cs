using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public GameObject modelPrefab;
    public int currentAmmo; // Текущие патроны
    public int maxAmmo; // Максимальные патроны для этого оружия

    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            Debug.Log("Firing " + weaponName);
            currentAmmo--;
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }
}
