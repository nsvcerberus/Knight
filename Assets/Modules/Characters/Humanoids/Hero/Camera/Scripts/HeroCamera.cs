using UnityEngine;
using Zenject;

namespace Fight.Gameplay.Hero.Camera
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
            heroManager.mouseActions.MouseBiasXUpdated += RotateX;
            heroManager.mouseActions.MouseBiasYUpdated += RotateY;

            heroManager.directions.GetMoveDirectionForward += GetDirectionForward;
            heroManager.directions.GetMoveDirectionForwardRight += GetDirectionForwardRight;
            heroManager.directions.GetMoveDirectionForwardLeft += GetDirectionForwardLeft;
            heroManager.directions.GetMoveDirectionBack += GetDirectionBack;
            heroManager.directions.GetMoveDirectionBackRight += GetDirectionBackRight;
            heroManager.directions.GetMoveDirectionBackLeft += GetDirectionBackLeft;
            heroManager.directions.GetMoveDirectionRight += GetDirectionRight;
            heroManager.directions.GetMoveDirectionLeft += GetDirectionLeft;
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


        public Vector3 GetDirectionForward() => new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        public Vector3 GetDirectionForwardRight() => GetDirectionForward() + GetDirectionRight();
        public Vector3 GetDirectionForwardLeft() => GetDirectionForward() + GetDirectionLeft();
        public Vector3 GetDirectionBack() => -GetDirectionForward();
        public Vector3 GetDirectionBackRight() => GetDirectionBack() + GetDirectionRight();
        public Vector3 GetDirectionBackLeft() => GetDirectionBack() + GetDirectionLeft();
        public Vector3 GetDirectionRight() => new Vector3(transform.right.x, 0, transform.right.z).normalized;
        public Vector3 GetDirectionLeft() => -GetDirectionRight();
    }
}