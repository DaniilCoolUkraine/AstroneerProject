using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Astroneer.Interactable.Puzzles
{
    public class DragObject : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public event Action OnRealse;
        
        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private TrailRenderer _trail;
        
        private Vector3 _mouseOffset;
        private Vector3 _startPosition;
        
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _startPosition = transform.localPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            
            if (eventData.delta.magnitude == 0)
            {
                _mouseOffset = transform.position - mouseWorldPos;
            }
            
            _rb.MovePosition(mouseWorldPos + _mouseOffset);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _rb.velocity = Vector2.zero;
            OnRealse?.Invoke();
        }

        public void ResetAll()
        {
            transform.localPosition = _startPosition;
            _trail.Clear();
        }
    }
}