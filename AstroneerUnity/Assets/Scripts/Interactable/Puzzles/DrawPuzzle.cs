using System.Collections;
using Astroneer.Interactable.Puzzles.PathFiller;
using Astroneer.Interactable.Puzzles.PathPoints;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public class DrawPuzzle : Puzzle
    {
        [SerializeField] private PathPointManager _pathPointManager;
        [SerializeField] private PathFillerManager _pathFillerManager;

        [SerializeField] private DragObject _handle;
        [SerializeField] private TrailRenderer _trail;
        
        private void OnEnable()
        {
            _handle.OnRealse += CheckWin;
        }

        private void OnDisable()
        {
            _handle.OnRealse -= CheckWin;
        }

        public override void Show()
        {
            base.Show();
            StartCoroutine(EnableHandleTrail());
        }

        public override void Hide()
        {
            base.Hide();
            _trail.enabled = false;
        }

        private IEnumerator EnableHandleTrail()
        {
            yield return new WaitForSeconds(_transitionDuration);
            _trail.enabled = true;
        }
        
        private void CheckWin()
        {
            _onPuzzleStarted.ChangeValue(false);
            
            if (_pathPointManager.IsAllPointsPassed)
            {
                _onPuzzleCompleted.ChangeValue(true);
            }
            else
            {
                _onPuzzleCompleted.ChangeValue(false);

                _pathPointManager.ResetAll();
                _pathFillerManager.ResetAll();
                _handle.ResetAll();
            }
        }
    }
}