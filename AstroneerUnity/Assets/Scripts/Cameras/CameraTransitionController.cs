using Astroneer.ScriptableObjects.Events;
using UnityEngine;

namespace Astroneer.Cameras
{
    public class CameraTransitionController : MonoBehaviour
    {
        [SerializeField] private SpriteOverlay _overlay;
        [SerializeField] private BoolEventSO _onPuzzleStarted;

        private void OnEnable()
        {
            _onPuzzleStarted.OnValueChanged += _overlay.DoFade;
        }
        
        private void OnDisable()
        {
            _onPuzzleStarted.OnValueChanged -= _overlay.DoFade;
        }
    }
}