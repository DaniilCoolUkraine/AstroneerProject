using Astroneer.ScriptableObjects.Events;
using UnityEngine;

namespace Astroneer.Interactable.Puzzles
{
    public abstract class Puzzle : Interactable
    {
        [SerializeField] protected BoolEventSO _onPuzzleCompleted;
    }
}