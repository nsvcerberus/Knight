using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fight.Level.Characters.Heroes
{
    public class AnimatorManager
    {
        public event Func<Animator> GetAnimator;

        private Dictionary<string, string> parameters;


        public AnimatorManager()
        {
            parameters = new Dictionary<string, string>()
            {
                {"keyIdle", "Idle"},
                {"keyGoForward", "GoForward"},
                {"keyRunForward", "RunForward"}
            };
        }


        public void SetAnimation(Controllers.Data.Actions action)
        {
            switch (action)
            {
                case Controllers.Data.Actions.Idle:
                    PlayAnimationIdle();
                    break;
                case Controllers.Data.Actions.Go:
                    PlayAnimationGoForward();
                    break;
                case Controllers.Data.Actions.Run:
                    PlayAnimationRunForward();
                    break;
            }
        }

        public void PlayAnimationIdle() => SetPartameter(parameters["keyIdle"]);
        public void PlayAnimationGoForward() => SetPartameter(parameters["keyGoForward"]);
        public void PlayAnimationRunForward() => SetPartameter(parameters["keyRunForward"]);


        public void SetPartameter(string parameter)
        {
            ResetParameters();
            OnGetAnimator().SetBool(parameter, true);
        }

        private void ResetParameters()
        {
            foreach (var parameter in parameters.Values)
                if (OnGetAnimator().GetBool(parameter))
                    OnGetAnimator().SetBool(parameter, false);
        }

        private Animator OnGetAnimator() => GetAnimator?.Invoke();
    }
}