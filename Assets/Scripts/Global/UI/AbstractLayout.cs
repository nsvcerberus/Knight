using System;
using UnityEngine;

namespace Fight.Userinterface.Global
{
    public abstract class AbstractLayout : MonoBehaviour
    {
        public event Action Enabled;
        public event Action Disabled;


        protected virtual void Awake() { }


        public virtual void Enable()
        {
            SetActive(true);
            Enabled?.Invoke();
        }

        public virtual void Disable()
        {
            SetActive(false);
            Disabled?.Invoke();
        }


        private void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}