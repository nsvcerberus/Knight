using System;
using UnityEngine;

namespace Fight.Gameplay.Hero
{
    public class KeyboardActions
    {
        public event Action<bool> StateForwardUpdated;
        public event Action<bool> StateLeftUpdated;
        public event Action<bool> StateRightUpdated;
        public event Action<bool> StateBackUpdated;


        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.W))
                OnStateForwardUpdated(true);
            else if (Input.GetKeyUp(KeyCode.W))
                OnStateForwardUpdated(false);

            if (Input.GetKeyDown(KeyCode.S))
                OnStateBackUpdated(true);
            else if (Input.GetKeyUp(KeyCode.S))
                OnStateBackUpdated(false);

            if (Input.GetKeyDown(KeyCode.A))
                OnStateLeftUpdated(true);
            else if (Input.GetKeyUp(KeyCode.A))
                OnStateLeftUpdated(false);

            if (Input.GetKeyDown(KeyCode.D))
                OnStateRightUpdated(true);
            else if (Input.GetKeyUp(KeyCode.D))
                OnStateRightUpdated(false);
        }


        private void OnStateForwardUpdated(bool state) => StateForwardUpdated?.Invoke(state);
        private void OnStateBackUpdated(bool state) => StateBackUpdated?.Invoke(state);
        private void OnStateLeftUpdated(bool state) => StateLeftUpdated?.Invoke(state);
        private void OnStateRightUpdated(bool state) => StateRightUpdated?.Invoke(state);
    }
}