using Astroneer.Player;
using UnityEngine;

namespace Astroneer.Interactable
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        // possibly can be an error
        private IInteractor _interactor;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _interactor = other.GetComponent<IInteractor>();

            if (_interactor == null)
            {
                return;
            }
            
            _sprite.color = Color.green;
            _interactor.Interactable.Add(this);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _interactor = other.GetComponent<IInteractor>();

            if (_interactor == null)
            {
                return;
            }
            
            _sprite.color = Color.white;
            _interactor.Interactable.Remove(this);
        }

        private void OnDisable()
        {
            _interactor.Interactable.Remove(this);
        }

        public abstract void Interact();
    }
}