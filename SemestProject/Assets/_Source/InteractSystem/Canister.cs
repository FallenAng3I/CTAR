using UnityEngine;
using WeaponSystem;

namespace InteractSystem
{
    public class Canister : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject playerCanisterModel; // Модель канистры на игроке
        [SerializeField] private GameObject playerRifle;         // Компонент оружия игрока
        [SerializeField] private Transform dropPosition;         // Точка сброса канистры

        private bool _isCarried; // В руках ли канистра

        public void Interact()
        {
            if (_isCarried)
            {
                DropCanister(); // Если канистра в руках, сбросить её
            }
            else
            {
                PickUpCanister(); // Если канистра на земле, поднять её
            }
        }

        private void PickUpCanister()
        {
            _isCarried = true;

            // Скрываем канистру в мире
            gameObject.SetActive(false);

            // Включаем модель канистры на игроке
            playerCanisterModel.SetActive(true);

            // Выключаем оружие игрока
            playerRifle.GetComponent<Rifle>().enabled = false;
        }

        private void DropCanister()
        {
            _isCarried = false;

            // Сбрасываем канистру перед игроком
            transform.position = dropPosition.position;
            transform.rotation = dropPosition.rotation;

            // Показываем канистру в мире
            gameObject.SetActive(true);

            // Выключаем модель канистры на игроке
            playerCanisterModel.SetActive(false);

            // Включаем оружие игрока
            playerRifle.GetComponent<Rifle>().enabled = true;
        }
    }
}