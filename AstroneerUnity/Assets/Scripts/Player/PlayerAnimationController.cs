using System;
using Astroneer.ScriptableObjects.Events;
using UnityEngine;

namespace Astroneer.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private BoolEventSO _onPlayerMove;
        
        [SerializeField] private Animator _animator;

        private readonly string _isRunningParameter = "isRunning";

        private void OnEnable()
        {
            _onPlayerMove.OnValueChanged += PlayRunAnimation;
        }

        private void OnDisable()
        {
            _onPlayerMove.OnValueChanged -= PlayRunAnimation;
        }

        private void PlayRunAnimation(bool isRunning)
        {
            _animator.SetBool(_isRunningParameter, isRunning);
        }
    }
}