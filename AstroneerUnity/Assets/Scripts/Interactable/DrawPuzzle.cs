using Astroneer.Player;
using UnityEngine;

namespace Astroneer.Interactable
{
    public class DrawPuzzle : MonoBehaviour, IInteractable
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            IInteractor interactor = other.GetComponent<IInteractor>();

            if (interactor == null)
            {
                return;
            }
            
            interactor.Interactable = this;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IInteractor interactor = other.GetComponent<IInteractor>();

            if (interactor == null)
            {
                return;
            }
            
            interactor.Interactable = null;
        }

        public void Interact()
        {
            Debug.Log("Interacted");
        }
    }
}