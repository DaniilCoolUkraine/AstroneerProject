using UnityEngine;

namespace Astroneer.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly string _isRunningParameter = "isRunning";
        private readonly string _isInteractingParameter = "isInteracting";
        
        public void PlayRunAnimation(bool isRunning)
        {
            _animator.SetBool(_isRunningParameter, isRunning);
        }

        public void PlayInteractAnimation(bool isInteracting)
        {
            if (isInteracting)
            {
                _animator.SetTrigger(_isInteractingParameter);
                return;
            }
            _animator.ResetTrigger(_isInteractingParameter);
        }
    }
}