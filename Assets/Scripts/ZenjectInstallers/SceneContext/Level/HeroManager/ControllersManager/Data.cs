using System;
using UnityEngine;

namespace Fight.Level.Characters.Heroes.Controllers
{
    public class Data
    {
        public event Action<Actions> ActionUpdated;

        public Vector3 Direction { get; private set; }

        public enum Actions
        {
            Idle,
            Go,
            Run
        }
        public Actions Action { get; private set; }


        private void SetDirection(Vector3 direction) => Direction = direction;


        public void SetActionIdle()
        {
            OnActionUpdated(Actions.Idle);
            SetDirection(Vector3.zero);
        }

        public void SetActionGo(Vector3 direction)
        {
            OnActionUpdated(Actions.Go);
            SetDirection(direction);
        }

        public void SetActionRun(Vector3 direction)
        {
            OnActionUpdated(Actions.Run);
            SetDirection(direction);
        }


        private void OnActionUpdated(Actions action) => ActionUpdated?.Invoke(Action = action);
    }
}