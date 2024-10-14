using System;
using UnityEngine;

namespace _Source.NewWeaponScript
{
    public abstract class AWeapon : WeaponInfo
    {
        private void Start()
        {
            andWeapons = FindObjectOfType<PlayerAndWeapons>();
        }

        public virtual void Shoot()
        {
            
        }
        public void Scope()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                scope = true;
            }
            else
            {
                scope = false;
            }
        }
    }
}