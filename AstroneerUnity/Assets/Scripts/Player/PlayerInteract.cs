using System;
using Astroneer.Interactable;
using UnityEngine;

namespace Astroneer.Player
{
    public class PlayerInteract : MonoBehaviour, IInteractor
    {
        public event Action<bool> OnPlayerInteract;
        
        public IInteractable Interactable { get; set; }
        
        private void Update()
        {
            if (Interactable == null)
                return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interactable.Interact();

                OnPlayerInteract?.Invoke(true);
            }
        }
    }
}