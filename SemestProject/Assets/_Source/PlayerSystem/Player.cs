using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        public float speed;
        public GameObject weapon;

        private void Update()
        {
            WeaponView();
        }

        public void WeaponView()
        {
            Rifle playerRifle = GetComponent<Rifle>();

            if (playerRifle.GetComponent<Rifle>().enabled == true)
            {
                weapon.SetActive(true);
            }
        }
    }
}
