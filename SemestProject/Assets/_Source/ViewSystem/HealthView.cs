using System;
using PlayerSystem;
using UnityEngine;

namespace ViewSystem
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private GameObject health1;
        [SerializeField] private GameObject health2;
        [SerializeField] private Player player;

        private void Start()
        {
            health1.SetActive(false);
            health2.SetActive(false);
        }

        private void Update()
        {
            HealthCheck();
        }

        private void HealthCheck()
        {
            if (player.health == 2)
            {
                health1.SetActive(true);
                health2.SetActive(false);
            }
            else if (player.health == 1 || player.health == 0)
            {
                health1.SetActive(false);
                health2.SetActive(true);
            }
            else
            {
                health1.SetActive(false);
                health2.SetActive(false);
            }
        }
    }
}
