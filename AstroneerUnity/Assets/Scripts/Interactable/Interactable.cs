using Astroneer.Player;
using UnityEngine;

namespace Astroneer.Interactable
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        [SerializeField] private Material _outlineMaterial;
        [SerializeField] private Material _defaultMaterial;
        
        // possibly can be an error
        private IInteractor _interactor;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _interactor = other.GetComponent<IInteractor>();

            if (_interactor == null)
            {
                return;
            }
            
            _sprite.material = _outlineMaterial;
            _interactor.Interactable = this;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactor = other.GetComponent<IInteractor>();

            if (_interactor == null)
            {
                return;
            }

            _sprite.material = _defaultMaterial;
            _interactor.Interactable = null;
        }
        
        public abstract void Interact();
    }
}