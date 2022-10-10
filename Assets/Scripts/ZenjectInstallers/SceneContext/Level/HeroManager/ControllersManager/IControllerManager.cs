using System;
using UnityEngine;

namespace Fight.Level.Characters.Heroes
{
    public interface IControllerManager
    {
        event Action Idle;
        event Action<Vector3> Go;
        event Action<Vector3> Run;
        public event Action<float> CameraRotateX;
        public event Action<float> CameraRotateY;
        event Func<Vector3> GetCameraTransformForward;
    }
}