using Astroneer.ScriptableObjects.Events;
using UnityEngine;

namespace Astroneer.Interactable
{
    public class Door : Interactable
    {
        [SerializeField] private BoolEventSO _onPuzzleComplete;

        private bool _canBeOpened = false;
        
        private void OnEnable()
        {
            _onPuzzleComplete.OnValueChanged += SetCanBeOpened;
        }
        
        private void OnDisable()
        {
            _onPuzzleComplete.OnValueChanged -= SetCanBeOpened;
        }

        public override void Interact()
        {
            if (_canBeOpened)
            {
                Destroy(gameObject);
            }
        }

        private void SetCanBeOpened(bool state)
        {
            _canBeOpened = state;
        }
    }
}