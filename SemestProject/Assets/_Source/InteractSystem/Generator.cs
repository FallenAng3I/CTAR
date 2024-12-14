using UnityEngine;

namespace InteractSystem
{
    public class Generator : MonoBehaviour
    {
        private int _requiredCanisters;      // Количество канистр для завершения задания
        private int _collectedCanisters;    // Сколько канистр уже принесено

        private void OnTriggerEnter(Collider other)
        {
            var canister = other.GetComponent<Canister>();
            if (!canister) return;
            Destroy(other.gameObject);
            //_collectedCanisters++;
        }
    }
}
