using Cinemachine;
using UnityEngine;

namespace Astroneer.Interactable
{
    public class CameraSwitcher : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera[] _cameras;
        
        public void SwitchToCamera(CinemachineVirtualCamera camera)
        {
            for (int i = 0; i < _cameras.Length; i++)
            {
                _cameras[i].Priority = 0;
            }

            camera.Priority = 10;
        }
    }
}