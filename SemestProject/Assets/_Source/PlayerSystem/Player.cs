using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        public int health;
        public float speed;
        public GameObject weapon;
        public Rifle rifle;

        private void Update()
        {
            WeaponView();
            ReadSpeed();
        }

        private void ReadSpeed()
        {
            if (rifle.canShoot || rifle.isReloading)
            {
                speed = (float)2.5;
            }
            else
            {
                speed = 5;
            }
        }

        public void WeaponView()
        {
            Rifle playerRifle = GetComponent<Rifle>();

            if (playerRifle.GetComponent<Rifle>().enabled == true)
            {
                weapon.SetActive(true);
            }
        }

        private void Death()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
