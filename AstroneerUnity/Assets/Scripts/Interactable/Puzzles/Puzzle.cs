using Astroneer.ScriptableObjects.Events;
using DG.Tweening;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public abstract class Puzzle : MonoBehaviour
    {
        [SerializeField] protected BoolEventSO _onPuzzleCompleted;

        [SerializeField] private Transform _endPosition;
        
        private Vector2 _startPosition;

        private void Awake()
        {
            _startPosition = transform.localPosition;
        }

        public void Show()
        {
            transform.DOLocalMove(_endPosition.position, 1);
        }

        public void Hide()
        {
            transform.DOLocalMove(_startPosition, 1);
        }
    }
}