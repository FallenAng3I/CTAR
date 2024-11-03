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
            if (weapon.enabled)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    weapon.Shoot();
                }            
            }
        }
        
        private void ReadScope()
        {
            if (weapon.enabled)
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    weapon.canShoot = true;
                    weapon.Scope();
                }
                else
                {
                    weapon.canShoot = false;
                }
            }
        }        

        private void ReadReload()
        {
            if (weapon.enabled)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    weapon.Reload();
                }            
            }
        }
    }
}
