using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class InputListener : MonoBehaviour
    {
        public Player player;
        public Rifle weapon;
        
        private void Update()
        {
            ReadShoot();
            ReadReload();
            ReadScope();
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

        private void ReadScope()
        {
            if (weapon.enabled == true)
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    weapon.Scope();
                }
            }
        }
    }
}
