using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class InputListener : MonoBehaviour
    {
        public Rifle weapon;
        
        private void Update()
        {
            ReadShoot();
            ReadReload();
        }

        private void ReadShoot()
        {
            if (weapon.enabled == true)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    weapon.Shoot();
                }            
            }
        }

        private void ReadReload()
        {
            if (weapon.enabled == true)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    weapon.Reload();
                }            
            }
        }
    }
}
