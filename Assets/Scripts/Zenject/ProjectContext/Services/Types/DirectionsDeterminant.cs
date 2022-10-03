using UnityEngine;

namespace Fight.Zenject.ProjectContext.Services
{
    public class DirectionsDeterminant
    {
        public Vector3 GetDirectionForward(Transform transform) => transform.forward;
        public Vector3 GetDirectionForwardLeft(Transform transform) => (-transform.right + transform.forward).normalized;
        public Vector3 GetDirectionForwardRight(Transform transform) => (transform.right + transform.forward).normalized;
        public Vector3 GetDirectionBack(Transform transform) => -transform.forward;
        public Vector3 GetDirectionBackLeft(Transform transform) => (-transform.right - transform.forward).normalized;
        public Vector3 GetDirectionBackRight(Transform transform) => (transform.right - transform.forward).normalized;
        public Vector3 GetDirectionLeft(Transform transform) => -transform.right;
        public Vector3 GetDirectionRight(Transform transform) => transform.right;
        public Vector3 GetDirectionUp(Transform transform) => transform.up;
        public Vector3 GetDirectionBottom(Transform transform) => -transform.up;
    }
}