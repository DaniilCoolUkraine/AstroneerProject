using System;
using UnityEngine;

namespace Astroneer.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "EventSO", menuName = "ScriptableObjects/Events/EventSO", order = 0)]
    public class EventSO : ScriptableObject
    {
        public event Action OnInvoked;

        public void Invoke()
        {
            OnInvoked?.Invoke();
        }
    }
}