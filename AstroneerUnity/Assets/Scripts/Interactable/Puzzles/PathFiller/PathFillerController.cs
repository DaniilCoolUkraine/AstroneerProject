using Astroneer.General;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles.PathFiller
{
    public class PathFillerController : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        private void Start()
        {
            SetBlock(false);
        }

        public void SetBlock(bool isActive)
        {
            _collider.isTrigger = !isActive;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Constants.TAG_DRAGABLE_CIRCLE))
            {
                SetBlock(true);
            }
        }
    }
}