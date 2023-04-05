using Astroneer.ScriptableObjects.Events;
using DG.Tweening;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public abstract class Puzzle : MonoBehaviour
    {
        [SerializeField] protected BoolEventSO _onPuzzleCompleted;
        [SerializeField] protected BoolEventSO _onPuzzleStarted;

        private Camera _mainCamera;
        [SerializeField] protected float _transitionDuration;
        
        private Vector2 _endPosition;
        private Vector2 _startPosition;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _startPosition = transform.localPosition;
        }

        public virtual void Show()
        {
            _endPosition = (Vector2)_mainCamera.transform.position - new Vector2(3, 3);
            transform.DOMove(_endPosition, _transitionDuration);
        } 

        public virtual void Hide()
        {
            transform.DOLocalMove(_startPosition, _transitionDuration);
        }
    }
}