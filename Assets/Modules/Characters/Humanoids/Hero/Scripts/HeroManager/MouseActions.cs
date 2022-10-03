using System;
using UnityEngine;

namespace Fight.Gameplay.Hero
{
    public class MouseActions
    {
        public event Action<float> MouseBiasXUpdated;
        public event Action<float> MouseBiasYUpdated;
        public event Action<bool> StateMouseButtonLeftUpdated;
        public event Action<bool> StateMouseButtonRightUpdated;


        public void Tick()
        {
            if (Input.GetAxis("Mouse X") != 0)
                MouseBiasXUpdated?.Invoke(Input.GetAxis("Mouse X"));

            if (Input.GetAxis("Mouse Y") != 0)
                MouseBiasYUpdated?.Invoke(Input.GetAxis("Mouse Y"));

            if (Input.GetMouseButtonDown(0))
                OnStateMouseButtonLeftUpdated(true);
            else
                OnStateMouseButtonLeftUpdated(false);

            if (Input.GetMouseButtonDown(1))
                OnStateMouseButtonRightUpdated(true);
            else
                OnStateMouseButtonRightUpdated(false);
        }

        private void OnStateMouseButtonLeftUpdated(bool state) => StateMouseButtonLeftUpdated?.Invoke(state);
        private void OnStateMouseButtonRightUpdated(bool state) => StateMouseButtonRightUpdated?.Invoke(state);
    }
}