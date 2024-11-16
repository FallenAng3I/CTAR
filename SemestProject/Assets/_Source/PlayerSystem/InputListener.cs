using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class InputListener : MonoBehaviour
    {
        public Player player;
        public Rifle weapon;
        
        public LayerMask interactableLayer;
        
        private void Update()
        {
            ReadShoot();
            ReadReload();
            ReadUse();
            Scope();
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
        
        private void Scope()
        {
            if (weapon.enabled)
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    weapon.canShoot = true;
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

        private void ReadUse()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.Use();
            }
        }
    }
}
