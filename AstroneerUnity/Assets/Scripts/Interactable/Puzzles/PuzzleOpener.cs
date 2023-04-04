using Astroneer.ScriptableObjects.Events;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public class PuzzleOpener : Interactable
    {
        // todo add background sprite overlay (to fade background) 
        
        // [SerializeField] private CinemachineVirtualCamera _puzzleWatchingCamera;
        // [SerializeField] private CinemachineVirtualCamera _defaultCamera;
        //
        // [SerializeField] protected CameraSwitcher _cameraSwitcher;

        [SerializeField] private BoolEventSO _onPuzzleCompleted;
        [SerializeField] private BoolEventSO _onPuzzleStarted;

        private void OnEnable()
        {
            _onPuzzleCompleted.OnValueChanged += _onPuzzleStarted.ChangeValue;
        }
        
        private void OnDisable()
        {
            _onPuzzleCompleted.OnValueChanged -= _onPuzzleStarted.ChangeValue;
        }

        public override void Interact()
        {
            _onPuzzleStarted.ChangeValue(true);
            // _cameraSwitcher.SwitchToCamera(_puzzleWatchingCamera);
        }

        // private void SetDefaultCamera()
        // {
        //     _cameraSwitcher.SwitchToCamera(_defaultCamera);
        // }
    }
}