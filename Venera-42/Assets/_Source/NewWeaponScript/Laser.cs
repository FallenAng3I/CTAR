using UnityEngine;

namespace _Source.NewWeaponScript
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private PlayerAndWeapons inv;
        [SerializeField] private AWeapon weapon;
        [SerializeField] private GameObject laser;

        void Start()
        {
            laser.GetComponent<Renderer>().enabled = false;
        }

        void Update()
        {
            if (inv.currentWeapon != null)
            {
                if (inv.currentWeapon.scope)
                {
                    laser.GetComponent<Renderer>().enabled = true;
                }
                else
                {
                    laser.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }
}