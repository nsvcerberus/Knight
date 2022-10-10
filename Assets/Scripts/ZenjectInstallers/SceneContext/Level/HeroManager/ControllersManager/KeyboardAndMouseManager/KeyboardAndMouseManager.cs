using System;
using UnityEngine;

namespace Fight.Level.Characters.Heroes.Controllers.KeyboardAndMouse
{
    public class KeyboardAndMouseManager : IControllerManager
    {
        public event Action Idle;
        public event Action<Vector3> Go;
        public event Action<Vector3> Run;
        public event Action<float> CameraRotateX;
        public event Action<float> CameraRotateY;
        public event Func<Vector3> GetCameraTransformForward;

        private readonly Keyboard.KeyboardManager keyboardManager = new Keyboard.KeyboardManager();
        private readonly Mouse.MouseManager mouseManager = new Mouse.MouseManager();


        public KeyboardAndMouseManager()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            keyboardManager.data.Updated += DefineAction;
            mouseManager.MouseBiasXUpdated += MouseBiasX;
            mouseManager.MouseBiasYUpdated += MouseBiasY;
        }


        public void Tick()
        {
            keyboardManager.Tick();
            mouseManager.Tick();
        }


        private void MouseBiasX(float value)
        {
            OnCameraRotateX(value);
            DefineAction();
        }

        private void MouseBiasY(float value)
        {
            OnCameraRotateY(value);
            DefineAction();
        }


        private void DefineAction()
        {
            if (keyboardManager.data.CheckIfIdle())
            {
                Idle?.Invoke();
            }
            else
            {
                if (!keyboardManager.data.CheckIfIdle())
                {
                    if (keyboardManager.data.PressedForward)
                    {
                        if (keyboardManager.data.PressedLeft)
                            MoveForwardLeft();
                        else if (keyboardManager.data.PressedRight)
                            MoveForwardRight();
                        else
                            MoveForward();
                    }

                    else if (keyboardManager.data.PressedBack)
                    {
                        if (keyboardManager.data.PressedLeft)
                            MoveBackLeft();
                        else if (keyboardManager.data.PressedRight)
                            MoveBackRight();
                        else
                            MoveBack();
                    }

                    else if (keyboardManager.data.PressedRight)
                    {
                        MoveRight();
                    }

                    else if (keyboardManager.data.PressedLeft)
                    {
                        MoveLeft();
                    }
                }
            }
        }


        public void MoveForward() => Move(OnGetCameraTransformForward());
        public void MoveForwardRight() => Move(RotateVectorForward(45));
        public void MoveForwardLeft() => Move(RotateVectorForward(-45));
        public void MoveBack() => Move(RotateVectorForward(180));
        public void MoveBackRight() => Move(RotateVectorForward(135));
        public void MoveBackLeft() => Move(RotateVectorForward(-135));
        public void MoveRight() => Move(RotateVectorForward(90));
        public void MoveLeft() => Move(RotateVectorForward(-90));

        private void Move(Vector3 direction)
        {
            if (keyboardManager.data.PressedRun)
                Run?.Invoke(direction);
            else
                Go?.Invoke(direction);
        }

        private Vector3 RotateVectorForward(int angle) => Quaternion.Euler(0, angle, 0) * OnGetCameraTransformForward();
        private void OnCameraRotateX(float value) => CameraRotateX?.Invoke(value);
        private void OnCameraRotateY(float value) => CameraRotateY?.Invoke(value);
        private Vector3 OnGetCameraTransformForward() => GetCameraTransformForward.Invoke();
    }
}