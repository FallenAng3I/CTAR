using UnityEngine;

namespace _Source.NewWeaponScript
{
    public class Laser : MonoBehaviour
    {
        public PlayerAndWeapons inv;
        public AWeapon weapon;
        public GameObject laser;

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