using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Fight.Gameplay.Hero
{
    [RequireComponent(typeof(Animator))]
    public class HeroAvatar : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private Dictionary<string, string> parameters;

        [Inject] public HeroManager heroManager;


        private void Awake()
        {
            parameters = new Dictionary<string, string>()
            {
                {"keyIdle", "Idle"},
                {"keyGoForward", "GoForward"},
                {"keyGoLeft", "GoLeft"},
                {"keyGoRight", "GoRight"},
                {"keyGoBack", "GoBack"}/*,
                {"keyRunForward", "RunForward"},
                {"keyRunLeft", "RunLeft"},
                {"keyRunRight", "RunRight"},
                {"keyRunBack", "RunBack"}*/
            };

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            heroManager.directions.GetMoveDirectionForwardFromAvatar += GetTransformForward;
            heroManager.states.Updated += SetAnimation;
            /*
            heroManager.SetAnimationIdle += PlayAnimationIdle;
            heroManager.SetAnimationMoveGoForward += PlayAnimationGoForward;
            heroManager.SetAnimationMoveGoBack += PlayAnimationGoBack;
            heroManager.SetAnimationMoveGoRight += PlayAnimationGoRight;
            heroManager.SetAnimationMoveGoLeft += PlayAnimationGoForward;
            */

            //heroManager.states.Updated += SetAnimation;
        }


        private void Update()
        {
            if (!heroManager.states.CheckIfIdle())
            {
                Vector3 direction = Vector3.zero;

                if (heroManager.states.MoveForward)
                {
                    if (heroManager.states.MoveLeft)
                        direction = heroManager.directions.OnGetMoveDirectionForwardLeft();
                    else if (heroManager.states.MoveRight)
                        direction = heroManager.directions.OnGetMoveDirectionForwardRight();
                    else
                        direction = heroManager.directions.OnGetMoveDirectionForward();
                }

                else if (heroManager.states.MoveBack)
                {
                    if (heroManager.states.MoveLeft)
                        direction = heroManager.directions.OnGetMoveDirectionBackLeft();
                    else if (heroManager.states.MoveRight)
                        direction = heroManager.directions.OnGetMoveDirectionBackRight();
                    else
                        direction = heroManager.directions.OnGetMoveDirectionBack();
                }

                else if (heroManager.states.MoveRight)
                {
                    direction = heroManager.directions.OnGetMoveDirectionRight();
                }

                else if (heroManager.states.MoveLeft)
                {
                    direction = heroManager.directions.OnGetMoveDirectionLeft();
                }

                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), 100 * Time.deltaTime);
            }
        }


        private Vector3 GetTransformForward() => transform.forward;

        
        public void RotateY(float angle)
        {
            transform.Rotate(Vector3.up, angle, Space.Self);
        }


        private void SetAnimation()
        {
            if (!heroManager.states.CheckIfIdle())
            {
                if (heroManager.states.FocusOnEnemy)
                {

                }
                else
                {
                    PlayAnimationGoForward();
                }
            }
            else
            {
                PlayAnimationIdle();
            }
        }

        public void PlayAnimationIdle() => SetPartameter(parameters["keyIdle"]);
        public void PlayAnimationGoForward() => SetPartameter(parameters["keyGoForward"]);
        public void PlayAnimationGoBack() => SetPartameter(parameters["keyGoBack"]);
        public void PlayAnimationGoLeft() => SetPartameter(parameters["keyGoLeft"]);
        public void PlayAnimationGoRight() => SetPartameter(parameters["keyGoRight"]);
        public void PlayAnimationRunForward() => SetPartameter(parameters["keyRunForward"]);
        public void PlayAnimationRunBack() => SetPartameter(parameters["keyRunBack"]);
        public void PlayAnimationRunLeft() => SetPartameter(parameters["keyRunLeft"]);
        public void PlayAnimationRunRight() => SetPartameter(parameters["keyRunRight"]);


        public void SetPartameter(string parameter)
        {
            ResetParameters();
            animator.SetBool(parameter, true);
        }

        private void ResetParameters()
        {
            foreach (var parameter in parameters.Values)
                if (animator.GetBool(parameter))
                    animator.SetBool(parameter, false);
        }
    }
}