using System;
using UnityEngine;
using Fight.Level.Characters.Heroes.Controllers;
using Zenject;
using Fight.Installers.Level.Gameplay;

namespace Fight.Level.Characters.Heroes
{
    public sealed class HeroManager : ITickable
    {
        public event Func<Vector3> GetCameraTransformForward;

        public readonly ControllersManager controllerManager = new ControllersManager();
        public readonly Data data = new Data();

        [Inject] private GameplayManager gameplayManager;


        public HeroManager()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            controllerManager.GetCameraTransformForward += OnGetCameraTransformForward;
        }


        public void Tick()
        {
            if (gameplayManager.states.State == States.Types.Play)
                controllerManager.Tick();
        }


        private Vector3 OnGetCameraTransformForward() => GetCameraTransformForward.Invoke();
    }
}