using UnityEngine;
using Zenject;

namespace Fight.Gameplay.Hero
{
    public class Hero : Character
    {
        [Inject] private HeroManager heroManager;


        protected override void Awake()
        {
            base.Awake();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            //heroManager.CameraAngleByYUpdated += Rotate;
        }

        
        private void Update()
        {
            SetState();
        }

        private void SetState()
        {
            if (!heroManager.states.CheckIfIdle())
            {
                if (heroManager.states.FocusOnEnemy)
                {
                    if (heroManager.states.MoveForward)
                    {
                        if (heroManager.states.MoveLeft)
                            GoForwardLeft();
                        else if (heroManager.states.MoveRight)
                            GoForwardRight();
                        else
                            GoForward();
                    }

                    else if (heroManager.states.MoveBack)
                    {
                        if (heroManager.states.MoveLeft)
                            GoBackLeft();
                        else if (heroManager.states.MoveRight)
                            GoBackRight();
                        else
                            GoBack();
                    }

                    else if (heroManager.states.MoveRight)
                    {
                        GoRight();
                    }

                    else if (heroManager.states.MoveLeft)
                    {
                        GoLeft();
                    }
                }
                else
                {
                    Go(heroManager.directions.OnGetMoveDirectionForwardFromAvatar());
                }
            }
        }

        private void Go(Vector3 direction) => MoveCharacter(direction, goSpeed);
        public void GoForward() => MoveCharacter(heroManager.directions.OnGetMoveDirectionForward(), goSpeed);
        public void GoForwardRight() => MoveCharacter(heroManager.directions.OnGetMoveDirectionForwardRight(), goSpeed);
        public void GoForwardLeft() => MoveCharacter(heroManager.directions.OnGetMoveDirectionForwardLeft(), goSpeed);
        public void GoBack() => MoveCharacter(heroManager.directions.OnGetMoveDirectionBack(), goSpeed);
        public void GoBackRight() => MoveCharacter(heroManager.directions.OnGetMoveDirectionBackRight(), goSpeed);
        public void GoBackLeft() => MoveCharacter(heroManager.directions.OnGetMoveDirectionBackLeft(), goSpeed);
        public void GoLeft() => MoveCharacter(heroManager.directions.OnGetMoveDirectionLeft(), goSpeed);
        public void GoRight() => MoveCharacter(heroManager.directions.OnGetMoveDirectionRight(), goSpeed);
    }
}