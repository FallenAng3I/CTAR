using UnityEngine;

namespace InteractSystem
{
    public class Glass : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}
