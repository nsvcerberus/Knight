using System;
using UnityEngine;

namespace Fight.Level.Characters.Heroes.Controllers.KeyboardAndMouse.Mouse
{
    public class MouseManager
    {
        public event Action<float> MouseBiasXUpdated;
        public event Action<float> MouseBiasYUpdated;

        public readonly Data data = new Data();


        public void Tick()
        {
            if (Input.GetAxis("Mouse X") != 0)
                MouseBiasXUpdated?.Invoke(Input.GetAxis("Mouse X"));

            if (Input.GetAxis("Mouse Y") != 0)
                MouseBiasYUpdated?.Invoke(Input.GetAxis("Mouse Y"));

            /*
            if (Input.GetMouseButtonDown(0))
                OnStateMouseButtonLeftUpdated(true);
            else
                OnStateMouseButtonLeftUpdated(false);

            if (Input.GetMouseButtonDown(1))
                OnStateMouseButtonRightUpdated(true);
            else
                OnStateMouseButtonRightUpdated(false);
            */
        }
    }
}