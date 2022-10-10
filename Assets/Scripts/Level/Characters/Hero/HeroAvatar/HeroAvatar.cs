using UnityEngine;
using Zenject;

namespace Fight.Level.Characters.Heroes
{
    [RequireComponent(typeof(Animator))]
    public class HeroAvatar : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float rotationSpeed;

        [Inject] public HeroManager heroManager;
        private AnimatorManager animatorManager = new AnimatorManager();


        private void Awake()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            heroManager.controllerManager.data.ActionUpdated += animatorManager.SetAnimation;
            animatorManager.GetAnimator += () => animator;
        }


        private void Update()
        {
            RotateY();
        }


        public void RotateY()
        {
            if (heroManager.controllerManager.data.Action != Controllers.Data.Actions.Idle)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(heroManager.controllerManager.data.Direction), rotationSpeed * 100 * Time.deltaTime);
        }
    }
}