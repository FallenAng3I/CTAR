using UnityEngine;

namespace ViewSystem
{
    public class WeaponIK : MonoBehaviour
    {
        public Transform leftHandTarget;  // Точка для левой руки
        public Transform rightHandTarget; // Точка для правой руки
        public Animator animator;         // Ссылка на аниматор персонажа

        private void OnAnimatorIK(int layerIndex)
        {
            //if (animator == null) return;
            
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
            
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
        }
    }
}