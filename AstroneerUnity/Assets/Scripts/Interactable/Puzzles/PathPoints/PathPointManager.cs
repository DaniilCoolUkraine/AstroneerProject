using UnityEngine;

namespace Astroneer.Interactable.Puzzles.PathPoints
{
    public class PathPointManager : MonoBehaviour
    {
        public bool IsAllPointsPassed => _currentPassPoints == _pointController.Length;
        
        [SerializeField] private PathPointController[] _pointController;

        private int _currentPassPoints;

        private void Start()
        {
            foreach (PathPointController point in _pointController)
            {
                point.OnPointPassed += IncreasePassedPoints;
            }
        }
        
        public void ResetAll()
        {
            _currentPassPoints = 0;
            foreach (PathPointController point in _pointController)
            {
                point.IsPassed = false;
            }
        }

        private void IncreasePassedPoints()
        {
            _currentPassPoints++;
        }
        
    }
}