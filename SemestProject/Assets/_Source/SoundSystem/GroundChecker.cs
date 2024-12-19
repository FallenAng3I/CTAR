using UnityEngine;

namespace SoundSystem
{
    public class GroundChecker : MonoBehaviour
    {
        public FootstepManager footstepManager;

        private void OnTriggerStay(Collider other)
        {
            string surfaceName = LayerMask.LayerToName(other.gameObject.layer);
            if (!string.IsNullOrEmpty(surfaceName))
            {
                footstepManager.UpdateSurface(surfaceName);
            }
        }
    }
}