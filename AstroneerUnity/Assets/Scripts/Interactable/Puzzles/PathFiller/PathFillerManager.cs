using UnityEngine;

namespace Astroneer.Interactable.Puzzles.PathFiller
{
    public class PathFillerManager : MonoBehaviour
    {
        [SerializeField] private PathFillerController[] _pathFillers;

        public void ResetAll()
        {
            foreach (PathFillerController pathFiller in _pathFillers)
            {
                pathFiller.SetBlock(false);
            }
        }
    }
}