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
        
        private void OnEnable()
        {
            _handle.OnRealse += CheckWin;
        }

        private void OnDisable()
        {
            _handle.OnRealse -= CheckWin;
        }

        private void CheckWin()
        {
            if (_pathPointManager.IsAllPointsPassed)
            {
                _onPuzzleCompleted.ChangeValue(true);
                Debug.Log("win");
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