using Astroneer.ScriptableObjects.Events;
using Cinemachine;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public class PuzzleOpener : Interactable
    {
        [Header("Cameras")]
        
        [SerializeField] private CinemachineVirtualCamera _puzzleWatchingCamera;
        [SerializeField] private CinemachineVirtualCamera _defaultCamera;
        
        [SerializeField] protected CameraSwitcher _cameraSwitcher;

        [SerializeField] private BoolEventSO _onPuzzleCompleted;

        private void OnEnable()
        {
            _onPuzzleCompleted.OnValueChanged += (bool value) => SetDefaultCamera();
        }

        public override void Interact()
        {
            _cameraSwitcher.SwitchToCamera(_puzzleWatchingCamera);
        }

        private void SetDefaultCamera()
        {
            _cameraSwitcher.SwitchToCamera(_defaultCamera);
        }
    }
}