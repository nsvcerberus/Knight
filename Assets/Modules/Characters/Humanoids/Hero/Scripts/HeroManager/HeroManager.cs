using Zenject;

namespace Fight.Gameplay.Hero
{
    public class HeroManager : ITickable
    {
        public readonly KeyboardActions keyboardActions = new KeyboardActions();
        public readonly MouseActions mouseActions = new MouseActions();
        public readonly States states = new States();
        public readonly Directions directions = new Directions();


        public HeroManager()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            keyboardActions.StateForwardUpdated += states.SetMoveForward;
            keyboardActions.StateLeftUpdated += states.SetMoveLeft;
            keyboardActions.StateRightUpdated += states.SetMoveRight;
            keyboardActions.StateBackUpdated += states.SetMoveBack;
        }


        public void Tick()
        {
            keyboardActions.Tick();
            mouseActions.Tick();
        }

        /*
        public event Action<float> CameraAngleByYUpdated;
        public void OnCameraAngleByYUpdated(float angle) => CameraAngleByYUpdated?.Invoke(angle);
        */
    }
}