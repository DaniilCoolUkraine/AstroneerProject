using Astroneer.ScriptableObjects.Events;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public class PuzzleManager : MonoBehaviour
    {
        [SerializeField] private BoolEventSO _onPuzzleStarted;
        [SerializeField] private BoolEventSO _onPuzzleCompleted;

        [SerializeField] private Puzzle[] _puzzles;

        private int _currentPuzzleIndex;
        private Puzzle CurrentPuzzle => _puzzles[_currentPuzzleIndex];

        private void OnEnable()
        {
            _onPuzzleStarted.OnValueChanged += SwitchPuzzle;
            _onPuzzleCompleted.OnValueChanged += IncrementPuzzleIndex;
        }
        
        private void OnDisable()
        {
            _onPuzzleStarted.OnValueChanged -= SwitchPuzzle;
            _onPuzzleCompleted.OnValueChanged -= IncrementPuzzleIndex;
        }

        private void SwitchPuzzle(bool isShow)
        {
            if (isShow)
            {
                CurrentPuzzle.Show();
            }
            else
            {
                CurrentPuzzle.Hide();
            }
        }

        private void IncrementPuzzleIndex(bool isIncrement)
        {
            if (isIncrement && _currentPuzzleIndex < _puzzles.Length-1)
            {
                _currentPuzzleIndex++;
            }
        }
    }
}