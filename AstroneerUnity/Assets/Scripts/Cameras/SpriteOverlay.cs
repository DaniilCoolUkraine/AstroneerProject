using DG.Tweening;
using UnityEngine;

namespace Astroneer.Cameras
{
    public class SpriteOverlay : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private float _transitionDuration;

        private void Start()
        {
            float height = 2f * _mainCamera.orthographicSize;
            float width = height * _mainCamera.aspect;
            
            _sprite.transform.localScale = new Vector2(width, height);
        }

        public void DoFade(bool isFade)
        {
            float fadeValue = isFade ? 0.5f : 0;
            _sprite.DOFade(fadeValue, _transitionDuration);
        }
    }
}