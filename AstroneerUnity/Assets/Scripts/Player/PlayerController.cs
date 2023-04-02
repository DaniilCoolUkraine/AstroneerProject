using UnityEngine;

namespace Astroneer.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerInteract _playerInteract;

        [SerializeField] private PlayerAnimationController _animationController;

        private void OnEnable()
        {
            _playerMovement.OnPlayerMove += _animationController.PlayRunAnimation;
            _playerInteract.OnPlayerInteract += _animationController.PlayInteractAnimation;
        }

        private void OnDisable()
        {
            _playerMovement.OnPlayerMove -= _animationController.PlayRunAnimation;
            _playerInteract.OnPlayerInteract -= _animationController.PlayInteractAnimation;
        }
    }
}