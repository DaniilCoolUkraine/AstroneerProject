using Astroneer.ScriptableObjects.Events;
using UnityEngine;

namespace Astroneer.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private BoolEventSO _onPuzzleStarted;
        
        [SerializeField] private PlayerMovement _playerMovement;

        [SerializeField] private PlayerInteract _playerInteract;

        [SerializeField] private PlayerAnimationController _animationController;

        private void OnEnable()
        {
            _playerMovement.OnPlayerMove += _animationController.PlayRunAnimation;
            _playerInteract.OnPlayerInteract += _animationController.PlayInteractAnimation;

            _onPuzzleStarted.OnValueChanged += SetControls;
        }

        private void OnDisable()
        {
            _playerMovement.OnPlayerMove -= _animationController.PlayRunAnimation;
            _playerInteract.OnPlayerInteract -= _animationController.PlayInteractAnimation;
            
            _onPuzzleStarted.OnValueChanged -= SetControls;
        }

        private void SetControls(bool isState)
        {
            _playerMovement.enabled = !isState;
            _playerInteract.enabled = !isState;
        }
    }
}