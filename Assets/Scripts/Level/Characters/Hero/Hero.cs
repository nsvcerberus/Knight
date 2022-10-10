using UnityEngine;
using Zenject;

namespace Fight.Level.Characters.Heroes
{
    public sealed class Hero : Character
    {
        [Inject] private HeroManager heroManager;

        
        private void FixedUpdate()
        {
            DefineAction();
        }

        private void DefineAction()
        {
            var action = heroManager.controllerManager.data.Action;

            if (action != Controllers.Data.Actions.Idle)
            {
                var direction = heroManager.controllerManager.data.Direction;

                switch (action)
                {
                    case Controllers.Data.Actions.Go:
                        Go(direction); 
                        break;
                    case Controllers.Data.Actions.Run:
                        Run(direction);
                        break;
                }
            }
        }


        private void Go(Vector3 direction) => MoveCharacter(direction, goSpeed);
        private void Run(Vector3 direction) => MoveCharacter(direction, runSpeed);
    }
}