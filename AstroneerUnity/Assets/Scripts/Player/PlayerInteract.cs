using System;
using System.Collections.Generic;
using Astroneer.Interactable;
using UnityEngine;

namespace Astroneer.Player
{
    public class PlayerInteract : MonoBehaviour, IInteractor
    {
        public event Action<bool> OnPlayerInteract;
        
        public List<IInteractable> Interactable { get; set; }

        private void Awake()
        {
            Interactable = new List<IInteractable>();
        }

        private void Start()
        {
            Interactable.Clear();
        }

        private void Update()
        {
            if (Interactable == null)
                return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (IInteractable interactable in Interactable)
                {
                    interactable.Interact();   
                }
                
                OnPlayerInteract?.Invoke(true);
            }
        }
    }
}