using System;
using UnityEngine;

namespace Fight.Gameplay.Hero.Camera
{
    public class MouseActionsManager
    {
        public event Action<float> MouseBiasXUpdated;
        public event Action<float> MouseBiasYUpdated;


        public void Update()
        {
            if (Input.GetAxis("Mouse X") != 0)
                MouseBiasXUpdated?.Invoke(Input.GetAxis("Mouse X"));

            if (Input.GetAxis("Mouse Y") != 0)
                MouseBiasYUpdated?.Invoke(Input.GetAxis("Mouse Y"));
        }
    }
}