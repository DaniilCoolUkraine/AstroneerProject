using System;
using Astroneer.General;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles.PathPoints
{
    public class PathPointController : MonoBehaviour
    {
        public event Action OnPointPassed;
        public bool IsPassed { get; set; }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!IsPassed && other.CompareTag(Constants.TAG_DRAGABLE_CIRCLE))
            {
                IsPassed = true;
                OnPointPassed?.Invoke();
            }
        }
    }
}