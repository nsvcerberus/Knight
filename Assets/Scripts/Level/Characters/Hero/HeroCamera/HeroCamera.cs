using UnityEngine;
using Zenject;

namespace Fight.Level.Characters.Heroes.Camera
{
	public class HeroCamera : MonoBehaviour
	{
        [Inject] private HeroManager heroManager;

        [SerializeField] private float rotationSpeed;
        [SerializeField, Range(0, 90)] private float topAngleRange;
        [SerializeField, Range(-90, 0)] private float bottomAngleRange;


        private void Awake()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            heroManager.controllerManager.CameraRotateX += RotateX;
            heroManager.controllerManager.CameraRotateY += RotateY;

            heroManager.GetCameraTransformForward += GetTransformForward;
        }


        private void RotateX(float angle)
        {
            Rotate(Vector3.up, angle, Space.World);
        }

        private void RotateY(float angle)
        {
            var eulerAngle = transform.localEulerAngles.x + (-angle);

            if (eulerAngle >= 360 + bottomAngleRange ||
                eulerAngle <= topAngleRange)
                Rotate(Vector3.right, -angle, Space.Self);
        }

        private void Rotate(Vector3 axis, float angle, Space space)
        {
            transform.Rotate(axis, angle * rotationSpeed * Time.deltaTime, space);
        }


        public Vector3 GetTransformForward() => new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
    }
}