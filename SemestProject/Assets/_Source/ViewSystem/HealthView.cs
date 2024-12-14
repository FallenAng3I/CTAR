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
            switch (player.health)
            {
                case 2:
                    health1.SetActive(true);
                    health2.SetActive(false);
                    break;
                case 1 or 0:
                    health1.SetActive(false);
                    health2.SetActive(true);
                    break;
                default:
                    health1.SetActive(false);
                    health2.SetActive(false);
                    break;
            }
        }
    }
}
