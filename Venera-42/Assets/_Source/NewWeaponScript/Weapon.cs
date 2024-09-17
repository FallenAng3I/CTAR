using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public abstract class Weapon : ScriptableObject
{
    public string weaponName;
    public GameObject modelPrefab;
    public int currentAmmo; // Текущие патроны
    public int maxAmmo;     // Максимальные патроны для этого оружия

    public abstract void Shoot();
}