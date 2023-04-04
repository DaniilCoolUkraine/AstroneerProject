using Astroneer.ScriptableObjects.Events;
using DG.Tweening;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public abstract class Puzzle : MonoBehaviour
    {
        [SerializeField] protected BoolEventSO _onPuzzleCompleted;
        [SerializeField] protected BoolEventSO _onPuzzleStarted;

        [SerializeField] protected float _transitionDuration;
        [SerializeField] private Transform _endPosition;
        
        private Vector2 _startPosition;

        private void Awake()
        {
            _startPosition = transform.localPosition;
        }

        public virtual void Show()
        {
            transform.DOLocalMove(_endPosition.position, _transitionDuration);
        }

        public virtual void Hide()
        {
            transform.DOLocalMove(_startPosition, _transitionDuration);
        }
    }
}