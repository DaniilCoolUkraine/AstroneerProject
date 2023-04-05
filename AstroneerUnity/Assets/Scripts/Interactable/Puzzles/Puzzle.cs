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

        [SerializeField] private Vector2 _offset;
        
        private Camera _mainCamera;
        
        private Vector2 _endPosition;
        private Vector2 _startPosition;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _startPosition = transform.localPosition;
        }

        public virtual void Show()
        {
            _endPosition = (Vector2) _mainCamera.transform.position - _offset;
            transform.DOMove(_endPosition, _transitionDuration);
        } 

        public virtual void Hide()
        {
            transform.DOLocalMove(_startPosition, _transitionDuration);
        }
    }
}