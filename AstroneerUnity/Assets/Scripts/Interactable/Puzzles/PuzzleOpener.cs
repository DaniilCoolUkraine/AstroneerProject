using Astroneer.ScriptableObjects.Events;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public class PuzzleOpener : Interactable
    {
        [SerializeField] private BoolEventSO _onPuzzleStarted;

        public override void Interact()
        {
            _onPuzzleStarted.ChangeValue(true);
        }
    }
}