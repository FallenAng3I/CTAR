using UnityEngine;

namespace WeaponSystem
{
    public class WeaponAttachment : MonoBehaviour
    {
        [Header("Attachment Point")]
        [SerializeField] private Transform attachmentPoint;  // Точка привязки оружия

        private void LateUpdate()
        {
            transform.position = attachmentPoint.position;
            transform.rotation = attachmentPoint.rotation;
        }
    }
}