using System;

namespace Fight.Level.Characters.Heroes.Controllers.KeyboardAndMouse.Keyboard
{
    public class Data
    {
        public event Action Updated;

        public bool PressedForward { get; private set; }
        public bool PressedBack { get; private set; }
        public bool PressedLeft { get; private set; }
        public bool PressedRight { get; private set; }
        public bool PressedRun { get; private set; }


        public bool CheckIfIdle()
        {
            if (PressedForward ||
                PressedBack ||
                PressedLeft ||
                PressedRight)
                return false;
            return true;
        }

        public void SetPressedForward(bool state)
        {
            PressedForward = state;
            OnUpdated();
        }

        public void SetPressedBack(bool state)
        {
            PressedBack = state;
            OnUpdated();
        }

        public void SetPressedLeft(bool state)
        {
            PressedLeft = state;
            OnUpdated();
        }

        public void SetPressedRight(bool state)
        {
            PressedRight = state;
            OnUpdated();
        }

        public void SetPressedRun(bool state)
        {
            PressedRun = state;
            OnUpdated();
        }


        public void OnUpdated() => Updated?.Invoke();
    }
}