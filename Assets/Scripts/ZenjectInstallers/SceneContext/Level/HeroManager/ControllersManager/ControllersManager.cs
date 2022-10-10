using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fight.Level.Characters.Heroes.Controllers
{
    public class ControllersManager
    {
        public event Action<float> CameraRotateX;
        public event Action<float> CameraRotateY;
        public event Func<Vector3> GetCameraTransformForward;

        public readonly Data data = new Data();
        private readonly KeyboardAndMouse.KeyboardAndMouseManager keyboardAndMouseManager = new KeyboardAndMouse.KeyboardAndMouseManager();
        private List<IControllerManager> controllers;
        

        public ControllersManager()
        {
            controllers = new List<IControllerManager>()
            {
                keyboardAndMouseManager
            };

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            foreach (var controller in controllers)
            {
                controller.Idle += data.SetActionIdle;
                controller.Go += data.SetActionGo;
                controller.Run += data.SetActionRun;
                controller.GetCameraTransformForward += OnGetCameraTransformForward;
                controller.CameraRotateX += OnCameraRotateX;
                controller.CameraRotateY += OnCameraRotateY;
            }
        }


        public void Tick()
        {
            keyboardAndMouseManager.Tick();
        }


        private Vector3 OnGetCameraTransformForward() => GetCameraTransformForward.Invoke();
        private void OnCameraRotateX(float value) => CameraRotateX?.Invoke(value);
        private void OnCameraRotateY(float value) => CameraRotateY?.Invoke(value);
    }
}