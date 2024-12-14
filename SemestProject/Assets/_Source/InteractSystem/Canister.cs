using UnityEngine;
using WeaponSystem;

namespace InteractSystem
{
    public class Canister : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject playerCanisterModel; // Модель канистры на игроке
        [SerializeField] private Transform dropPosition;         // Точка сброса канистры
        [SerializeField] private Rifle rifle;                    // Оружие игрока
        [SerializeField] private GameObject gui;

        private bool _isCarried;

        public void Interact()
        {
            if (_isCarried)
            {
                DropCanister();
            }
            else
            {
                PickUpCanister();
            }
        }

        private void PickUpCanister()
        {
            if (_isCarried) return;
            
            _isCarried = true;
            
            gameObject.SetActive(false);

            playerCanisterModel.SetActive(true);
            rifle.enabled = false;
            gui.SetActive(false);
        }

        public void DropCanister()
        {
            if (!_isCarried) return;
            
            _isCarried = false;
            
            transform.position = dropPosition.position;
            transform.rotation = dropPosition.rotation;
            gameObject.SetActive(true);

            playerCanisterModel.SetActive(false);
            rifle.enabled = true;
            gui.SetActive(true);
        }

    }
}


