using System;

namespace Fight.Gameplay.Hero
{
    public class States
    {
        public event Action Updated;

        public bool FocusOnEnemy { get; private set; }
        public bool MoveForward { get; private set; }
        public bool MoveBack { get; private set; }
        public bool MoveLeft { get; private set; }
        public bool MoveRight { get; private set; }
        public bool Run { get; private set; }


        public bool CheckIfIdle()
        {
            if (MoveForward ||
                MoveBack ||
                MoveLeft ||
                MoveRight)
                return false;
            return true;
        }

        public void SetMoveForward(bool state)
        {
            MoveForward = state;
            OnUpdated();
        }

        public void SetMoveBack(bool state)
        {
            MoveBack = state;
            OnUpdated();
        }

        public void SetMoveLeft(bool state)
        {
            MoveLeft = state;
            OnUpdated();
        }

        public void SetMoveRight(bool state)
        {
            MoveRight = state;
            OnUpdated();
        }


        public void OnUpdated() => Updated?.Invoke();
    }
}